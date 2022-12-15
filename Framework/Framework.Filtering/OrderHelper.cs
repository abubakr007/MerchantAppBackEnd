using Framework.Filtering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Filtering
{
    public static class OrderHelper
    {
        #region Process Data (sort, group)

        private static IOrderedQueryable OrderBy(this IQueryable source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }


        private static IOrderedQueryable OrderByDescending(this IQueryable source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }


        private static IOrderedQueryable ThenBy(this IOrderedQueryable source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }


        private static IOrderedQueryable ThenByDescending(this IOrderedQueryable source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }


        private static IOrderedQueryable ApplyOrder(IQueryable source, string property, string methodName)
        {
            //string[] props = property.Split('.');
            var type = source.ElementType;
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            //foreach (string prop in props)
            //{
            //    // reflection
            var pi = type.GetProperty(property);
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
            //}
            var delegateType = typeof(Func<,>).MakeGenericType(source.ElementType, type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods()
                .Single(method =>
                    method.Name == methodName &&
                    method.IsGenericMethodDefinition &&
                    method.GetGenericArguments().Length == 2 &&
                    method.GetParameters().Length == 2)
                .MakeGenericMethod(source.ElementType, type)
                .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable)result;
        }


        private static EnumerableQuery ApplyGroup(IQueryable source, string property, string methodName)
        {
            var props = property.Split('.');
            var type = source.ElementType;
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var prop in props)
            {
                // reflection
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(source.ElementType, type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods()
                .Single(method =>
                    method.Name == methodName &&
                    method.IsGenericMethodDefinition &&
                    method.GetGenericArguments().Length == 2 &&
                    method.GetParameters().Length == 2)
                .MakeGenericMethod(source.ElementType, type)
                .Invoke(null, new object[] { source, lambda });

            return (EnumerableQuery)result;
        }


        public static EnumerableQuery GroupBy(this IOrderedQueryable source, string property)
        {
            return ApplyGroup(source, property, "GroupBy");
        }


        public static IQueryable<TSource> GetOrderedQueryable<TSource>(this IQueryable<TSource> Query,
            IList<OrderInfo> orderInfos) where TSource : class
        {
            if (orderInfos == null)
                return Query;

            orderInfos = orderInfos.Where(a => !a.OrderType.Equals(OrderType.None)).ToList();

            if (orderInfos.Count == 0)
                return Query;

            IOrderedQueryable orderedQueryable = null;

            OrderInfo info = null;
            for (var i = 0; i < orderInfos.Count; i++)
            {
                info = orderInfos[i];
                if (info.OrderType.Equals(OrderType.ASC))
                {
                    if (i == 0)
                        orderedQueryable = OrderBy(Query, info.Property);
                    else
                        orderedQueryable = ThenBy(orderedQueryable, info.Property);
                }
                else if (info.OrderType.Equals(OrderType.DESC))
                {
                    if (i == 0)
                        orderedQueryable = OrderByDescending(Query, info.Property);
                    else
                        orderedQueryable = ThenByDescending(orderedQueryable, info.Property);
                }
            }

            var result = (IQueryable<TSource>)orderedQueryable;

            return result;
        }

        #endregion
    }
}
