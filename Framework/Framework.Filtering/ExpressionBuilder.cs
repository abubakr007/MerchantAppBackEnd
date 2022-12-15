using Framework.Filtering.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Framework.Filtering
{
    public class ExpressionBuilder
    {
        private static readonly MethodInfo
            containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        private static readonly MethodInfo startsWithMethod =
            typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

        private static readonly MethodInfo
            endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });


        public static Expression<Func<T, bool>> GetExpression<T>(List<FilterInfo> filters)
        {
            // No filters passed in 
            if (filters.Count == 0)
                return null;

            // Create the parameter for the ObjectType (typically the 'x' in your expression (x => 'x')
            // The "parm" string is used strictly for debugging purposes
            var param = Expression.Parameter(typeof(T), "parm");

            // Store the result of a calculated Expression
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]); // Create expression from a single instance
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0],
                    filters[1]); // Create expression that utilizes AndAlso mentality
            else
                // Loop through filters until we have created an expression for each
                while (filters.Count > 0)
                {
                    // Grab initial filters remaining in our List
                    var f1 = filters[0];
                    var f2 = filters[1];

                    // Check if we have already set our Expression
                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]); // First iteration through our filters
                    else
                        exp = Expression.AndAlso(exp,
                            GetExpression<T>(param, filters[0], filters[1])); // Add to our existing expression

                    filters.Remove(f1);
                    filters.Remove(f2);

                    // Odd number, handle this seperately
                    if (filters.Count == 1)
                    {
                        // Pass in our existing expression and our newly created expression from our last remaining filter
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));

                        // Remove filter to break out of while loop
                        filters.RemoveAt(0);
                    }
                }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }


        public static Expression GetExpression<T>(ParameterExpression param, FilterInfo filter)
        {
            // The member you want to evaluate (x => x.FirstName)
            var member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = null;
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            if (member.Type == typeof(TimeSpan))
            {
                var val = TimeSpan.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(DateTime))
            {
                var val = DateTime.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(DateTime?))
            {
                var val = DateTime.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(int?))
            {
                var val = int.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(long?))
            {
                var val = long.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(float?))
            {
                var val = float.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else if (member.Type == typeof(double?))
            {
                var val = double.Parse(filter.Value);
                constant = Expression.Constant(val, member.Type);
            }
            else
            {
                constant = Expression.Constant(Convert.ChangeType(filter.Value, member.Type));
            }

            switch (filter.Operator)
            {
                case Operator.Equals:
                    return Expression.Equal(member, constant);

                case Operator.NotEqual:
                    return Expression.NotEqual(member, constant);

                case Operator.Contains:

                    return Expression.Call(member, containsMethod, constant);

                case Operator.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Operator.GreaterThanOrEqualTo:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Operator.LessThan:
                    return Expression.LessThan(member, constant);

                case Operator.LessThanOrEqualTo:
                    return Expression.LessThanOrEqual(member, constant);

                case Operator.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case Operator.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }


        private static BinaryExpression GetExpression<T>(ParameterExpression param, FilterInfo filter1,
            FilterInfo filter2)
        {
            var result1 = GetExpression<T>(param, filter1);
            var result2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(result1, result2);
        }
    }
}

