using DWF.Models;
using DWF.Models.Match;
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
        [ActionName("Create")]
        public ActionResult CreateRound()
        {
            return View();
        }

        // POST: Round Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreateRound(RoundCreateMatchEdit model)
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

        [ActionName("Details")]
        public ActionResult RoundDetails(int id)
        {
            var svc = new RoundService();
            var model = svc.GetRoundById(id);

            return View(model);
        }

        // GET: Edit View
        [ActionName("Edit")]
        public ActionResult RoundEdit(int id)
        {
            var svc = new RoundService();
            var detail = svc.GetRoundById(id);
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
        [ActionName("Edit")]
        public ActionResult RoundEdit(int id, RoundEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.RoundId != id)
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

        [ActionName("Delete")]
        public ActionResult DeleteRound(int id)
        {
            var svc = new RoundService();
            var model = svc.GetRoundById(id);

            return View(model);
        }

        // DELETE
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var svc = new RoundService();

            svc.DeleteRound(id);

            TempData["SaveResult"] = "Your round was deleted.";

            return RedirectToAction("Index");
        }
    }
}