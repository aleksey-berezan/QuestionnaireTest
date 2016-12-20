using System.Data.Entity;

namespace Questionnaire.DomainModel
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}