using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLocker.Data;
using WeaponsLocker.Models.Ammunition;

namespace WeaponsLocker.Services
{
    public class AmmunitionService
    {
        public bool CreateAmmunition(AmmunitionCreate model)
        {
            var entity =
                new Ammunition()
                {
                    Id = model.Id,
                    Caliber = model.Caliber,
                    ProjectileType = model.ProjectileType,
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
                        .Where(e => e.AttachmentId = Attachment)
                        .Select(
                        e =>
                            new AttachmentListItem
                            {
                                AttachmentId = e.AttachmentId,
                                CreatedBy = e.CreatedBy,
                                AttachmentType = e.AttachmentType,
                            }
                            );
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
}
