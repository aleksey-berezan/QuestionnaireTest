using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public class Section : BaseEvolvableEntity
    {
        [Required]
        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; }

        public int QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }

        public int? NextSectionId { get; set; }
        public virtual Section NextSection { get; set; }

        protected override IEnumerable<BaseEvolvableEntity> GetImmediateChildren()
        {
            return Questions;
        }

        protected override BaseEvolvableEntity CloneInternal()
        {
            return new Section
            {
                Description = Description,
                QuestionnaireId = QuestionnaireId,
                Questions = CloneCollection(Questions),
            };
        }
    }
}