using System.Data.Entity.ModelConfiguration;
using Questionnaire.DomainModel.Model;

namespace Questionnaire.DomainModel.EntityConfigurations
{
    public class SelectedAnswerConfiguration : EntityTypeConfiguration<SelectedAnswer>
    {
        public SelectedAnswerConfiguration()
        {
            HasRequired(a => a.QuestionnaireSession)
                .WithOptional()
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Choice)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}