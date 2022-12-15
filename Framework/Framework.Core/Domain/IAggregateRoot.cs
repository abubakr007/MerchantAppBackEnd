using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Core.Domain
{
    public interface IAggregateRoot<TAggregateRoot> where TAggregateRoot : class, IEntityBase
    {
        IEnumerable<Expression<Func<TAggregateRoot, object>>> GetAggregateExpressions();
    }
}