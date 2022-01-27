using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeaponsLocker.Models.Attachment;
using WeaponsLocker.Services;

namespace WeaponsLocker.WebMVC.Controllers
{
    [Authorize]
    public class AttachmentController : Controller
    {
        // GET: Attachment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttachmentService(userId);
            var model = service.GetAttachment();
            return View(model);
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
                TempData["SaveResult"] = "Your Attachment was added.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Attachment could not be added");
            return View(model);
        }

        //Come back to this in the morning!!
        private AttachmentService CreateAttachmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AttachmentService(userId);
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
                    Usage = detail.Usage,
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
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateAttachmentService();
            var model = svc.GetAttachmentById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttachment(int id)
        {
            var service = CreateAttachmentService();
            service.Delete(id);
            TempData["SaveResult"] = "Your attachment was deleted";
            return RedirectToAction("Index");
        }
    } 
}