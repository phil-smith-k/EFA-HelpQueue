using HelpQueue.Models.Cohort;
using HelpQueue.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelpQueue.Controllers
{
    [Authorize]
    public class HelpQueueController : Controller
    {
        private readonly CohortService _cohortService = new CohortService();

        // GET: HelpQueue
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Student"))
                return RedirectToAction(nameof(Queue));

            var cohorts = await _cohortService.GetCohortListAsync();

            return View(cohorts);
        }

        // GET: HelpQueue/HelpQueue/{id?}
        public async Task<ActionResult> Queue(int? id)
        {
            var service = new CohortService(User.Identity.GetUserId());

            CohortDetail model = null;
            if (User.IsInRole("Student"))
            {
                model = await service.GetUserCohortDetailAsync(User.Identity.GetUserId());
                if (model is null)
                    return RedirectToAction(nameof(InactiveAccount));
            }
            else if (id.HasValue)
                model = await service.GetCohortById(id.Value);

            if (model is null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public ActionResult InactiveAccount()
        {
            return View();
        }
    }
}