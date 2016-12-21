using System.Collections.Generic;

namespace Questionnaire.DomainModel.Model
{
    public class Answer : BaseEntity
    {
        public int QuestionnaireSessionId { get; set; }
        public virtual QuestionnaireSession QuestionnaireSession { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual List<AnswerChoice> Choices { get; set; }
    }
}