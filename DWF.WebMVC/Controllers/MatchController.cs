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
            return View();

        }

        // GET: Match View
        public ActionResult CreateMatch()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult MatchDetails(int matchId)
        {
            var svc = new MatchService();
            var model = svc.GetMatchById(matchId);

            return View(model);
        }

         //GET: Match Edit View
       public ActionResult MatchEdit(int matchId)
       {
           var svc = new MatchService();
           var detail = svc.GetMatchById(matchId);
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
        public ActionResult MatchEdit(int matchId, MatchEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(model.MatchId != matchId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new MatchService();

            if (svc.UpdateMatch(model))
            {
                TempData["SaveResult"] = "Your match was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The match could not be updated.");
            return View(model);
        }

        // GET: Match Delete View
        public ActionResult DeleteMatch(int matchId)
        {
            var svc = new MatchService();
            var model = svc.GetMatchById(matchId);

            return View(model);
        }

        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int matchId)
        {
            var svc = new MatchService();

            svc.DeleteMatch(matchId);

            TempData["SaveResult"] = "Your match was deleted.";

            return RedirectToAction("Index");
        }
    }
}