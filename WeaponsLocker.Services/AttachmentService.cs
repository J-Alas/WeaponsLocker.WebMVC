using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLocker.Data;
using WeaponsLocker.Models.Attachment;

namespace WeaponsLocker.Services
{
    public class AttachmentService
    {
        public bool CreateAttachment(AttachmentCreate model)
        {
            var entity =
                new Attachment()
                {
                    AttachmentId = model.AttachmentId,
                    AttachmentType = model.AttachmentType,
                    CreatedBy = model.CreatedBy,
                    Usage = model.Usage,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attachments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AttachmentListItem> GetAttachment(int AttachmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Attachments
                        .Where(e => e.AttachmentId == AttachmentId)
                        .Select(
                        e =>
                            new AttachmentListItem
                            {
                                AttachmentId = e.AttachmentId,
                                CreatedBy = e.CreatedBy,
                                AttachmentType = e.AttachmentType,
                            });
                return query.ToArray();
            }
        }
        public AttachmentDetails GetAttachmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Attachments
                       .Single(e => e.AttachmentId == id);
                return
                    new AttachmentDetails
                    {
                        AttachmentId = entity.AttachmentId,
                        CreatedBy = entity.CreatedBy,
                        AttachmentType = entity.AttachmentType,
                    };
            }
        }
        public bool UpdateAttachment(AttachmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attachments
                        .Single(e => e.AttachmentId == model.AttachmentId);
                entity.AttachmentId = model.AttachmentId;
                entity.CreatedBy = model.CreatedBy;
                entity.AttachmentType = model.AttachmentType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int AttachmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attachments
                        .Single(e => e.AttachmentId == AttachmentId);
                ctx.Attachments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
