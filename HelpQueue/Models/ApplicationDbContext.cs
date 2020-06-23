using System.Data.Entity;
using HelpQueue.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HelpQueue.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CohortEntity> Cohorts { get; set; }
        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
    }
}