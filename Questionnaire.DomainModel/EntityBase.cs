using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questionnaire.DomainModel
{
    public abstract class EntityBase
    {
        [Required]
        public int Id { get; set; } // surrogate id

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

        protected abstract IEnumerable<EntityBase> GetImmediateChildren();

        protected abstract EntityBase CloneInternal();

        public EntityBase Clone()
        {
            var clone = CloneInternal();
            clone.EntityId = EntityId;
            clone.Version = Version;
            return clone;
        }

        protected List<TEntity> CloneCollection<TEntity>(IEnumerable<TEntity> list)
            where TEntity : EntityBase
        {
            return list.Select(x => x.Clone())
                .Cast<TEntity>()
                .ToList();
        }
    }
}