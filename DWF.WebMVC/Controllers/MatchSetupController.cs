﻿using DWF.Data;
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
        // GET: MatchSetup
        public ActionResult Index()
        {
            return View();
        }

        // GET: MatchSetup Create view
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MatchSetupCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(); 
        }

        // GET: MatchSetup Details View
        public ActionResult MatchSetupDetails(int matchSetupId)
        {
            var svc = CreateMatchSetupService();
            var model = svc.GetMatchSetupById(matchSetupId);

            return View(model);
        }

        // GET: MatchSetup Edit View
        public ActionResult MatchSetupEdit(int matchSetupId)
        {
            var svc = CreateMatchSetupService();
            var detail = svc.GetMatchSetupById(matchSetupId);
            var model =
                new MatchSetupEdit
                {
                    MatchSetupId = detail.MatchSetupId,
                    PlayerOneId = detail.PlayerOneId,
                    PlayerTwoId = detail.PlayerTwoId,
                    NumberOfSets = detail.NumberOfSets,
                    NumberOfLegs = detail.NumberOfLegs
                };

            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult DeleteMatchSetup(int matchSetupId)
        {
            var svc = CreateMatchSetupService();
            var model = svc.GetMatchSetupById(matchSetupId);

            return View(model);
        }

        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int matchSetupId)
        {
            var svc = CreateMatchSetupService();

            svc.DeleteMatchSetup(matchSetupId);
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