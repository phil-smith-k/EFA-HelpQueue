using HelpQueue.Models;
using HelpQueue.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpQueue.Services
{
    public class EnrollmentService
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentService()
        {
            _context = new ApplicationDbContext();
        }

        // Get Enrollments by Cohort Id
        public async Task<List<EnrollmentListItem>> GetEnrollmentByCohortIdAsync(int cohortId)
        {
            var cohort = await _context.Cohorts.FindAsync(cohortId);
            return cohort.Enrollments.Select(e => new EnrollmentListItem
            {
                CohortId = e.CohortId,
                CohortName = e.Cohort.Name,
                StudentId = e.StudentId,
                StudentName = e.Student.FullName,
                Enrolled = e.Enabled
            }).ToList();
        }
    }
}