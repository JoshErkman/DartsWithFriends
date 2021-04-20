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

        // GET: MatchSetup Create
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

        // Helper Method
        private MatchSetupService CreateMatchSetupService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new MatchSetupService(userId);
            return service;
        }
    }
}