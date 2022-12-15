using System.Collections.Generic;

namespace Framework.Core.Mapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source);
        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source);
    }
}