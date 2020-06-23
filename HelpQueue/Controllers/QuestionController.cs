using HelpQueue.Models.Questions;
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
    public class QuestionController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionCreate model)
        {
            model.StudentId = User.Identity.GetUserId();

            var service = new QuestionService();

            var result = await service.CreateQuestionAsync(model);

            return RedirectToAction("Queue", "HelpQueue");
        }
    }
}