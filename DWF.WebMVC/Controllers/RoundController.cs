using DWF.Models;
using DWF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DWF.WebMVC.Controllers
{
    public class RoundController : Controller
    {
        // GET: Round
        public ActionResult Index()
        {
            var svc = new RoundService();
            var model = svc.GetRounds();
            return View(model);
        }

        // GET: Round Create View
        public ActionResult CreateRound()
        {
            return View();
        }

        // POST: Round Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRound(RoundCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var svc = new RoundService();

            if (svc.CreateRound(model))
            {
                TempData["SaveResult"] = "Your round was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The round could not be created");

            return View(model);
        }

        public ActionResult RoundDetails(int roundId)
        {
            var svc = new RoundService();
            var model = svc.GetRoundById(roundId);

            return View(model);
        }

        // GET: Edit View
        public ActionResult RoundEdit(int roundId)
        {
            var svc = new RoundService();
            var detail = svc.GetRoundById(roundId);
            var model =
                new RoundEdit
                {
                    RoundId = detail.RoundId,
                    TotalPoints = detail.TotalPoints,
                    MatchId = detail.MatchId
                };

            return View(model);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoundEdit(int roundId, RoundEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.RoundId != roundId)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new RoundService();

            if (svc.UpdateRound(model))
            {
                TempData["SaveResult"] = "Your round was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The round could not be updated");
            return View(model);
        }

        public ActionResult DeleteRound(int roundId)
        {
            var svc = new RoundService();
            var model = svc.GetRoundById(roundId);

            return View(model);
        }

        // DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int roundId)
        {
            var svc = new RoundService();

            svc.DeleteRound(roundId);

            TempData["SaveResult"] = "Your round was deleted.";

            return RedirectToAction("Index");
        }
    }
}