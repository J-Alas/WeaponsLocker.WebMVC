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
        private readonly Guid _userid;
        public AmmunitionService(Guid userId)
        {
            _userid = userId;
        }
        public bool CreateAmmunition(AmmunitionCreate model)
        {
            var entity =
                new Data.Ammunition()
                {
                    OwnerId = _userid,
                    Caliber = model.Caliber,
                    ProjectileType = model.ProjectileType,
                    Usage = model.Usage,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ammunitions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AmmunitionListItem>GetAmmunition()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ammunitions
                        .Where(e => e.OwnerId == _userid)
                        .Select(
                        e =>
                            new AmmunitionListItem
                            {
                                AmmoId = e.AmmoId,
                                Caliber = e.Caliber,
                                ProjectileType = e.ProjectileType,
                                Usage=e.Usage,
                            }
                            );
                return query.ToArray();
            }
        }
        public AmmunitionDetails GetAmmunitionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Ammunitions
                       .Single(e => e.AmmoId == id && e.OwnerId == _userid);
                return
                    new AmmunitionDetails
                    {
                        AmmoId = entity.AmmoId,
                        Caliber = entity.Caliber,
                        ProjectileType = entity.ProjectileType,
                        Usage = entity.Usage,
                    };
            }
        }
        public bool UpdateAttachment(AmmunitionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ammunitions
                        .Single(e => e.AmmoId == model.AmmoId && e.OwnerId == _userid);
                entity.Caliber = model.Caliber;
                entity.ProjectileType = model.ProjectileType;
                entity.Usage = model.Usage;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int ammoId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ammunitions
                        .Single(e => e.AmmoId == ammoId && e.OwnerId == _userid);
                ctx.Ammunitions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
