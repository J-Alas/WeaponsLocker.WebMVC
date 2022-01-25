using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponsLocker.Models.Ammunition;
using WeaponsLocker.Services;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AmmunitionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAmmunitionService();

            if (service.CreateAmmunition(model))
            {
                TempData["SaveResult"] = "Your Ammo was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ammo could not be created");
            return View(model);
        }

        //Come back to this in the morning!!
        private AmmunitionService CreateAmmunitionService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmmunitionService();
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateAmmunitionService();
            var model = svc.GetAmmunitionById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAmmunitionService();
            var detail = service.GetAmmunitionById(id);
            var model =
                new AmmunitionEdit
                {
                    Id = detail.Id,
                    Caliber = detail.Caliber,
                    ProjectileType = detail.ProjectileType,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AmmunitionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateAmmunitionService();
            if (service.UpdateAttachment(model))
            {
                TempData["SaveResult"] = "Your ammo was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your ammo could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAmmunitionService();
            var model = svc.GetAmmunitionById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAmmunitionService();
            service.Delete(id);
            TempData["SaveResult"] = "Your ammo was deleted";
            return RedirectToAction("Index");
        }
    }
}