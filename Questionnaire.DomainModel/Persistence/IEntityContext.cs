using System.Linq;
using Questionnaire.DomainModel.Model;

namespace Questionnaire.DomainModel.Persistence
{
    public interface IEntityContext<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> Entities { get; }
    }
}