using DWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DWF.WebMVC.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            var model = new PlayerListItem[0];
            return View(model);
        }
    }
}