using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLocker.Data;
using WeaponsLocker.Models.Firearm;

namespace WeaponsLocker.Services
{
    public class FirearmService
    {
        public bool CreateFirearm(FirearmCreate model)
        {
            var entity =
                new Firearm()
                {
                    FirearmId = model.FirearmId,
                    CreatedBy = model.CreatedBy,
                    Model = model.Model,
                    LastCleaned = model.LastCleaned,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Firearms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<FirearmListItem> GetFirearms()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Firearms
                        .Where(e => e.FirearmId = FirearmId)
                        .Select(
                        e =>
                            new FirearmListItem
                            {
                                FirearmId = e.FirearmId,
                                CreatedBy = e.CreatedBy,
                                Model = e.Model,
                                LastCleaned = e.LastCleaned,
                            }
                            );
                return query.ToArray();
            }
        }
        public FirearmDetails GetFirearmById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Firearms
                       .Single(e => e.FirearmId == id);
                return
                    new FirearmDetails
                    {
                        FirearmId = entity.FirearmId,
                        CreatedBy = entity.CreatedBy,
                        Model = entity.Model,
                        LastCleaned = entity.LastCleaned,
                    };
            }
        }
        public bool UpdateFirearm(FirearmEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Firearms
                        .Single(e => e.FirearmId == model.FirearmId);
                entity.FirearmId = model.FirearmId;
                entity.CreatedBy = model.CreatedBy;
                entity.Model = model.Model;
                entity.LastCleaned = model.LastCleaned;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int FirearmId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Firearms
                        .Single(e => e.FirearmId == FirearmId);
                ctx.Firearms.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}