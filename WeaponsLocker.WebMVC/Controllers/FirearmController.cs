using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponsLocker.Models.Firearm;
using WeaponsLocker.Services;

namespace WeaponsLocker.WebMVC.Controllers
{
    [Authorize]
    public class FirearmController : Controller
    {
        // GET: Firearm
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FirearmService(userId);
            var model = service.GetFirearms();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirearmCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFirearmService();

            if (service.CreateFirearm(model))
            {
                TempData["SaveResult"] = "Your Firearm was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Firearm could not be created");
            return View(model);
        }

        //Come back to this in the morning!!
        private FirearmService CreateFirearmService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FirearmService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateFirearmService();
            var model = svc.GetFirearmById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateFirearmService();
            var detail = service.GetFirearmById(id);
            var model =
                new FirearmEdit
                {
                    FirearmId = detail.FirearmId,
                    CreatedBy = detail.CreatedBy,
                    GunModel = detail.GunModel,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FirearmEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FirearmId != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateFirearmService();
            if (service.UpdateFirearm(model))
            {
                TempData["SaveResult"] = "Your firearm was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your firearm could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFirearmService();
            var model = svc.GetFirearmById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFirearm(int id)
        {
            var service = CreateFirearmService();
            service.Delete(id);
            TempData["SaveResult"] = "Your firearm was deleted";
            return RedirectToAction("Index");
        }
    }
}
