using Framework.Core.Mapper;
using Framework.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Epay.ReadModel.Queries.Contracts
{
    public class QueryResult<TDestination> where TDestination : class
    {
        /// <summary>
        ///  test
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currentPageNumber"></param>
        /// <param name="totalPageCount"></param>
        public QueryResult(IList<TDestination> value, int currentPageNumber, int totalPageCount)
        {
            Value = value;
            TotalPageCount = totalPageCount;
            CurrentPageNumber = currentPageNumber;
        }


        public IList<TDestination> Value { get; private set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPageCount { get; private set; }


        public static QueryResult<TDestination> GetQueryResult<TSource>(IMapper mapper, IQueryable<TSource> query,
            QueryFilter Filters) where TSource : class
        {
            query = query.GetFilteredQueryable(Filters.FilterInfos).GetOrderedQueryable(Filters.OrderInfos);
            var skip = (Filters.Page - 1) * Filters.Count;
            var totalCount = query.Count();
            IList<TSource> result;
            if (Filters.Count <= 0)
                result = query.Skip(skip).ToList();
            else
                result = query.Skip(skip).Take(Filters.Count).ToList();

            var PageCount = (int)Math.Ceiling((double)totalCount / Filters.Count);

            return new QueryResult<TDestination>(mapper.Map<TDestination, TSource>(result), Filters.Page, PageCount);
        }
    }
}
