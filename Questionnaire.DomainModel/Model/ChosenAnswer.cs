namespace Questionnaire.DomainModel.Model
{
    public class SelectedAnswer : BaseEntity
    {
        public int QuestionnaireSessionId { get; set; }
        public virtual QuestionnaireSession QuestionnaireSession { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int ChoiceId { get; set; }
        public virtual Choice Choice { get; set; }
    }
}