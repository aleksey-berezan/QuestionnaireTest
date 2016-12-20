using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questionnaire.DomainModel
{
    public class Choice : EntityBase
    {
        [Required]
        public string Description { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int? NavigateToSectionId { get; set; }
        public virtual Section NavigateToSection { get; set; }

        public int Score { get; set; }

        protected override IEnumerable<EntityBase> GetImmediateChildren()
        {
            return Enumerable.Empty<EntityBase>();
        }

        protected override EntityBase CloneInternal()
        {
            return new Choice
            {
                Description = Description,
                QuestionId = QuestionId,
                Score = Score,
            };
        }
    }
}