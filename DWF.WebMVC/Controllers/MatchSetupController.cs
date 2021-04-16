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
        public ActionResult MatchSetupCreate()
        {
            return View();
        }
    }
}