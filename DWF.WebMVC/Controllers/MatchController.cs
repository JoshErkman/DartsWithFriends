using DWF.Models;
using DWF.Models.Match;
using DWF.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DWF.WebMVC.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            var svc = new MatchService();
            var model = svc.GetMatches();
            return View(model);
        }

        // GET: Match View
        [ActionName("Create")]
        public ActionResult CreateMatch()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreateMatch(MatchCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = new MatchService();

            if (svc.CreateMatch(model))
            {
                TempData["SaveResult"] = "Your match was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The match could not be created.");

            return View(model);
        }

        // GET: Match Details View
        [ActionName("Details")]
        public ActionResult MatchDetails(int id)
        {
            var svc = new MatchService();
            var model = svc.GetMatchById(id);

            return View(model);
        }

         //GET: Match Edit View
         [ActionName("Edit")]
       public ActionResult MatchEdit(int id)
       {
           var svc = new MatchService();
           var detail = svc.GetMatchById(id);
            var model =
                new MatchEdit
                {
                    MatchId = detail.MatchId,
                    PlayerOneNeededScore = detail.PlayerOneNeededScore,
                    PlayerTwoNeededScore = detail.PlayerTwoNeededScore,
                    SetScore = detail.SetScore,
                    LegScore = detail.LegScore,
                    PlayerOneAvgRoundScore = detail.PlayerOneAvgRoundScore,
                    PlayerTwoAvgRoundScore = detail.PlayerTwoAvgRoundScore
                };

            return View(model);
       }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult MatchEdit(int id, MatchEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(model.MatchId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new MatchService();

            if (svc.UpdateMatch(model))
            {
                TempData["SaveResult"] = "Your match was updated.";
                return RedirectToAction("Edit", "Match", new {id = id });
            }

            ModelState.AddModelError("", "The match could not be updated.");
            return View(model);
        }

        // GET: Match Delete View
        [ActionName("Delete")]
        public ActionResult DeleteMatch(int id)
        {
            var svc = new MatchService();
            var model = svc.GetMatchById(id);

            return View(model);
        }

        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var svc = new MatchService();

            svc.DeleteMatch(id);

            TempData["SaveResult"] = "Your match was deleted.";

            return RedirectToAction("Index");
        }
    }
}