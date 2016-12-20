using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}