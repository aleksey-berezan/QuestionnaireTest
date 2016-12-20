using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Questionnaire.DomainModel.Model
{
    public class Choice : BaseEvolvableEntity
    {
        [Required]
        public string Description { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int? NavigateToSectionId { get; set; }
        public virtual Section NavigateToSection { get; set; }

        public int Score { get; set; }

        protected override IEnumerable<BaseEvolvableEntity> GetImmediateChildren()
        {
            return Enumerable.Empty<BaseEvolvableEntity>();
        }

        protected override BaseEvolvableEntity CloneInternal()
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