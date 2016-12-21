using System.Data.Entity.ModelConfiguration;
using Questionnaire.DomainModel.Model;

namespace Questionnaire.DomainModel.EntityConfigurations
{
    public class AnswerChoiceConfiguration : EntityTypeConfiguration<AnswerChoice>
    {
        public AnswerChoiceConfiguration()
        {
            HasRequired(a => a.Choice)
                .WithOptional()
                .WillCascadeOnDelete(false);
        }
    }
}