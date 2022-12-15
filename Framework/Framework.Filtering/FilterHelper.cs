using Framework.Filtering.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Filtering
{
    public static class FilterHelper
    {
        public static IQueryable<TSource> GetFilteredQueryable<TSource>(this IQueryable<TSource> Query,
            IList<FilterInfo> filterInfos) where TSource : class
        {
            var ResultQuery = Query;

            if (filterInfos == null)
                return ResultQuery;

            filterInfos = filterInfos.Where(x => !string.IsNullOrEmpty(x.Value)).ToList();
            if (filterInfos.Count > 0)
            {
                var filterExpression = BuildPredicate<TSource>(filterInfos);
                ResultQuery = Query.Where(filterExpression);
            }

            return ResultQuery;
        }


        private static Expression<Func<T, bool>> BuildPredicate<T>(IList<FilterInfo> filters)
        {
            var predicate = ModPredicateBuilder.Create<T>(item => true);
            if (filters.Any() && !filters.Any(x => x.Logical == Logical.AND))
                filters.First().Logical = Logical.AND;

            foreach (var info in filters)
                if (info.Logical == Logical.OR)
                    predicate = predicate.Or(BuildExpression<T>(info));
                else
                    predicate = predicate.And(BuildExpression<T>(info));

            return predicate;
        }


        private static Expression<Func<T, bool>> BuildExpression<T>(FilterInfo info)
        {
            var param = Expression.Parameter(typeof(T), "parm");
            var exp = ExpressionBuilder.GetExpression<T>(param, info);
            var lambda = Expression.Lambda<Func<T, bool>>(exp, param);

            return lambda;
        }
    }
}
