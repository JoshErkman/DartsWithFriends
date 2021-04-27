using DWF.Data;
using DWF.Models.MatchSetup;
using DWF.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DWF.WebMVC.Controllers
{

    public class MatchSetupController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: MatchSetup
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new MatchSetupService(userId);
            var model = svc.GetMatchSetups();
            return View(model);
        }

       // GET: MatchSetup Create view
       [ActionName("Create")]
       public ActionResult CreateMatchSetup()
       {
            return View();
       }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreateMatchSetup(MatchSetupCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = CreateMatchSetupService();

          if (!svc.ValidateEmail(model))
          {
              ModelState.AddModelError("", "This email does not exist.");
              return View(model);
          }

            if (svc.CreateMatchSetup(model))
            {
                TempData["SaveResult"] = "Your match setup was created.";
                return RedirectToAction("Create", "Match");
            }

            ModelState.AddModelError("", "The match setup could not be created.");

            return RedirectToAction("Index", model);
        }

        // GET: MatchSetup Details View
        [ActionName("Details")]
        public ActionResult MatchSetupDetails(int id)
        {

            var svc = CreateMatchSetupService();
            var model = svc.GetMatchSetupById(id);

            return View(model);
        }

        // GET: MatchSetup Edit View

        [ActionName("Edit")]
        public ActionResult MatchSetupEdit(int id)
        {
            var svc = CreateMatchSetupService();
            var detail = svc.GetMatchSetupById(id);
            var model =
                new MatchSetupEdit
                {
                    MatchSetupId = detail.MatchSetupId,
                    PlayerOneEmail = detail.PlayerOneEmail,
                    PlayerTwoEmail = detail.PlayerTwoEmail,
                    NumberOfSets = detail.NumberOfSets,
                    NumberOfLegs = detail.NumberOfLegs
                };

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult MatchSetupEdit(int matchSetupId, MatchSetupEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.MatchSetupId != matchSetupId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = CreateMatchSetupService();

            if (svc.UpdateMatchSetup(model))
            {
                TempData["SaveResult"] = "Your match setup was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your match setup could not be updated");
            return View(model);
        }

        // GET Delete View
        [ActionName("Delete")]
        public ActionResult DeleteMatchSetup(int id)
        {
            var svc = CreateMatchSetupService();
            var model = svc.GetMatchSetupById(id);

            return View(model);
        }

        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var svc = CreateMatchSetupService();

            svc.DeleteMatchSetup(id);
            TempData["SaveResult"] = "Your match setup was deleted.";

            return RedirectToAction("Index");
        }

        // Helper Method
        private MatchSetupService CreateMatchSetupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new MatchSetupService(userId);
            return service;
        }
    }
}