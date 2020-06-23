using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Entities
{
    public class CohortEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<EnrollmentEntity> Enrollments { get; set; }
        public virtual List<QuestionEntity> Questions { get; set; }
    }
}