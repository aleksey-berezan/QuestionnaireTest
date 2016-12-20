using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; } // surrogate id
    }
}