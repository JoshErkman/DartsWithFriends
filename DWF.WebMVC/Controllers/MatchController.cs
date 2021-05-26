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
                new RoundCreateMatchEdit
                {
                    MatchId = detail.MatchId,
                    PlayerOneNeededScore = detail.PlayerOneNeededScore,
                    PlayerTwoNeededScore = detail.PlayerTwoNeededScore,
                    PlayerOneAvgRoundScore = detail.PlayerOneAvgRoundScore,
                    PlayerTwoAvgRoundScore = detail.PlayerTwoAvgRoundScore,
                    IsTurn = detail.IsTurn
                };

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public ActionResult MatchEdit(int id, RoundCreateMatchEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.MatchId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new MatchService();

           
            if (model.PlayerOneRoundScore > model.PlayerOneNeededScore)
            {
                TempData["P1Bust"] = "Player 1 BUSTED!";
            }
            else if (model.PlayerTwoRoundScore > model.PlayerTwoNeededScore)
            {
                TempData["P2Bust"] = "Player 2 BUSTED!";
            }


            if (model.PlayerOneNeededScore == model.PlayerOneRoundScore)
            {
                TempData["SaveResult"] = "Congratulations Player 1! You have won the match!";
                svc.UpdateMatch(model);
                return RedirectToAction("Index", "Home", new { id = id });
            }

            // Not Working
            if (model.PlayerTwoNeededScore == model.PlayerTwoRoundScore)
            {
                TempData["SaveResult"] = "Congratulations Player 2! You have won the match!";
                svc.UpdateMatch(model);
                return RedirectToAction("Index", "Home", new { id = id });
            }

            svc.UpdateMatch(model);
            return RedirectToAction("Edit", "Match", new { id = id });
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