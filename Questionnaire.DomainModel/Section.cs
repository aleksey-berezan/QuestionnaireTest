using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel
{
    public class Section : EntityBase
    {
        [Required]
        public string Description { get; set; }

        public virtual List<Question> Questions { get; set; }

        public int QuestionnaireId { get; set; }
        public Questionnaire Questionnaire { get; set; }

        public int NextSectionId { get; set; }
        public Section NextSection { get; set; }

        protected override IEnumerable<EntityBase> GetImmediateChildren()
        {
            return Questions;
        }

        protected override EntityBase CloneInternal()
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