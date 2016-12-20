using System;
using System.Collections.Generic;
using System.Linq;

namespace Questionnaire.DomainModel.Model
{
    public abstract class BaseEvolvableEntity : BaseEntity
    {
        public int EntityId { get; set; }

        public Guid Version { get; set; }

        public void AlignVersionAndEntityId()
        {
            if (EntityId <= 0)
            {
                EntityId = Id;
                Version = Guid.NewGuid();
                foreach (var child in GetImmediateChildren())
                {
                    child.AlignVersionAndEntityId();
                }
            }
        }

        protected abstract IEnumerable<BaseEvolvableEntity> GetImmediateChildren();

        protected abstract BaseEvolvableEntity CloneInternal();

        public BaseEvolvableEntity Clone()
        {
            var clone = CloneInternal();
            clone.EntityId = EntityId;
            clone.Version = Version;
            return clone;
        }

        protected List<TEntity> CloneCollection<TEntity>(IEnumerable<TEntity> list)
            where TEntity : BaseEvolvableEntity
        {
            return list.Select(x => x.Clone())
                .Cast<TEntity>()
                .ToList();
        }
    }
}