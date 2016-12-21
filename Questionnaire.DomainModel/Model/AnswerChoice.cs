namespace Questionnaire.DomainModel.Model
{
    public class AnswerChoice : BaseEntity
    {
        public int ChoiceId { get; set; }
        public virtual Choice Choice { get; set; }

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}