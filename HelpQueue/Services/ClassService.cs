using HelpQueue.Models;
using HelpQueue.Models.Cohort;
using HelpQueue.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HelpQueue.Services
{
    public class ClassService
    {
        private readonly ApplicationDbContext _context;
        public ClassService()   
        {
            _context = new ApplicationDbContext();
        }

        // Create Class
        public async Task<Response> CreateCohortAsync(CohortCreate model)
        {
            throw new NotImplementedException();
        }

        // Join Class

        // Enroll in class

        // Leave Class

        // Conclude Class
    }
}