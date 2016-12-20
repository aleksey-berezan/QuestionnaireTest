using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel
{
    public class Questionnaire : EntityBase
    {
        [Required]
        public string Description { get; set; }

        public virtual List<Section> Sections { get; set; }

        protected override IEnumerable<EntityBase> GetImmediateChildren()
        {
            return Sections;
        }

        protected override EntityBase CloneInternal()
        {
            return new Questionnaire
            {
                Description = Description,
                Sections = CloneCollection(Sections),
            };
        }
    }
}
