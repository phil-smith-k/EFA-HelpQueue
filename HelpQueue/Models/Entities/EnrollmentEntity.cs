using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpQueue.Models.Entities
{
    public class EnrollmentEntity
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Cohort))]
        public int CohortId { get; set; }
        public virtual CohortEntity Cohort { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Enabled { get; set; }
    }
}