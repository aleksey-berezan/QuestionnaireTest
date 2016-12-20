using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public class Question : BaseEvolvableEntity
    {
        [Required]
        public string Description { get; set; }

        public virtual List<Choice> Choices { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        protected override IEnumerable<BaseEvolvableEntity> GetImmediateChildren()
        {
            return Choices;
        }

        protected override BaseEvolvableEntity CloneInternal()
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