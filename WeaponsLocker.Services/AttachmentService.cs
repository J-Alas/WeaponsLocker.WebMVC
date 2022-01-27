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
        private readonly Guid _userid;
        public AttachmentService(Guid userId)
        {
            _userid = userId;
        }
        public bool CreateAttachment(AttachmentCreate model)
        {
            var entity =
                new Attachment()
                {
                    OwnerId = _userid,
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
        public IEnumerable<AttachmentListItem> GetAttachment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Attachments
                        .Where(e => e.OwnerId == _userid)
                        .Select(
                        e =>
                            new AttachmentListItem
                            {
                                AttachmentId = e.AttachmentId,
                                CreatedBy = e.CreatedBy,
                                AttachmentType = e.AttachmentType,
                                Usage = e.Usage,
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
                       .Single(e => e.AttachmentId == id && e.OwnerId == _userid);
                return
                    new AttachmentDetails
                    {
                        AttachmentId = entity.AttachmentId,
                        CreatedBy = entity.CreatedBy,
                        AttachmentType = entity.AttachmentType,
                        Usage = entity.Usage,
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
                        .Single(e => e.AttachmentId == model.AttachmentId && e.OwnerId == _userid);
                entity.AttachmentId = model.AttachmentId;
                entity.CreatedBy = model.CreatedBy;
                entity.AttachmentType = model.AttachmentType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int attachmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Attachments
                        .Single(e => e.AttachmentId == attachmentId && e.OwnerId == _userid);
                ctx.Attachments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
