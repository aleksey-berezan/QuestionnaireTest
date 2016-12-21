using System.Data.Entity.ModelConfiguration;
using Questionnaire.DomainModel.Model;

namespace Questionnaire.DomainModel.EntityConfigurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            HasRequired(a => a.QuestionnaireSession)
                .WithMany(a => a.Answers)
                .WillCascadeOnDelete(false);
        }
    }
}