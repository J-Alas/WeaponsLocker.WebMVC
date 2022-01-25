using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeaponsLocker.WebMVC.Controllers
{
    public class AmmunitionController : Controller
    {
        // GET: Ammunition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}