using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponsLocker.Models.Attachment;
using WeaponsLocker.Services;

namespace WeaponsLocker.WebMVC.Controllers
{
    public class AttachmentController : Controller
    {
        // GET: Attachment
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
        public ActionResult Create(AttachmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAttachmentService();

            if (service.CreateAttachment(model))
            {
                TempData["SaveResult"] = "Your Attachment was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Attachment could not be created");
            return View(model);
        }

        //Come back to this in the morning!!
        private AttachmentService CreateAttachmentService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttachmentService();
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateAttachmentService();
            var model = svc.GetAttachmentById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAttachmentService();
            var detail = service.GetAttachmentById(id);
            var model =
                new AttachmentEdit
                {
                    AttachmentId = detail.AttachmentId,
                    CreatedBy = detail.CreatedBy,
                    AttachmentType = detail.AttachmentType,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AttachmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AttachmentId != id)
            {
                ModelState.AddModelError("", "Id mismatch.");
                return View(model);
            }
            var service = CreateAttachmentService();
            if (service.UpdateAttachment(model))
            {
                TempData["SaveResult"] = "Your attachment was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your attachment could not be updated.");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAttachmentService();
            var model = svc.GetAttachmentById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAttachmentService();
            service.Delete(id);
            TempData["SaveResult"] = "Your attachment was deleted";
            return RedirectToAction("Index");
        }
    } 
}