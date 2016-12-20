using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public class Questionnaire : BaseEvolvableEntity
    {
        [Required]
        public string Description { get; set; }

        public EntityState EntityState { get; set; }

        public virtual List<Section> Sections { get; set; }

        protected override IEnumerable<BaseEvolvableEntity> GetImmediateChildren()
        {
            return Sections;
        }

        protected override BaseEvolvableEntity CloneInternal()
        {
            return new Questionnaire
            {
                Description = Description,
                Sections = CloneCollection(Sections),
            };
        }
    }
}
