using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.DomainModel.Model
{
    public class QuestionnaireSession : BaseEntity
    {
        public int QuestionnaireId { get; set; }
        public virtual Questionnaire Questionnaire { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsCompleted { get; set; }

        public int? CurrentQuestionId { get; set; }

        public virtual Question CurrentQuestion { get; set; }

        public virtual List<Answer> Answers { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}