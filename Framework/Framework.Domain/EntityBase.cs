using System;
using System.IO;
using System.Runtime.Serialization;
using Framework.Core.Domain;
using Framework.Core.Persistence;

namespace Framework.Domain
{
    [Serializable()]
    public abstract class EntityBase<TEntity> : IEntityBase where TEntity : class
    {
        private IEntityIdGenerator<TEntity> entityIdGenerator = null;


        public EntityBase()
        {
        }


        public EntityBase(IEntityIdGenerator<TEntity> entityIdGenerator)
        {
            this.entityIdGenerator = entityIdGenerator;
        }


        public long Id { get; private set; }


        protected void SetId()
        {
            if (entityIdGenerator == null)
            {
                throw new System.Exception(
                    "IEntityIdGenerator is Not Implemented or you forgot to put base(entityIdGenerator)");
            }

            Id = entityIdGenerator.GetNewId();
        }


        protected void SetId(long id)
        {
            Id = id;
        }
    }
}