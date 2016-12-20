using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel
{
    public class Question : EntityBase
    {
        [Required]
        public string Description { get; set; }

        public virtual List<Question> Choices { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        protected override IEnumerable<EntityBase> GetImmediateChildren()
        {
            return Choices;
        }

        protected override EntityBase CloneInternal()
        {
            return new Question
            {
                Description = Description,
                SectionId = SectionId,
                Choices = CloneCollection(Choices),
            };
        }
    }
}