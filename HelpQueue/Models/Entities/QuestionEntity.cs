using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Entities
{
    public class QuestionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreationTime { get; set; }

        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }

        [ForeignKey(nameof(Cohort))]
        public int CohortId { get; set; }
        public virtual CohortEntity Cohort { get; set; }
    }
}