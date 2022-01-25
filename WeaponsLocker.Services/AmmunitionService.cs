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

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ammunitions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AmmunitionListItem>GetAmmunition(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ammunitions
                        .Where(e => e.Id == Id)
                        .Select(
                        e =>
                            new AmmunitionListItem
                            {
                                Id = e.Id,
                                Caliber = e.Caliber,
                                ProjectileType = e.ProjectileType,
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
                       .Single(e => e.Id == id);
                return
                    new AmmunitionDetails
                    {
                        Id = entity.Id,
                        Caliber = entity.Caliber,
                        ProjectileType = entity.ProjectileType,
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
                        .Single(e => e.Id == model.Id);
                entity.Id = model.Id;
                entity.Caliber = model.Caliber;
                entity.ProjectileType = model.ProjectileType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ammunitions
                        .Single(e => e.Id == Id);
                ctx.Ammunitions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
