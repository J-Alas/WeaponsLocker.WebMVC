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
        private readonly Guid _userId;
        public FirearmService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateFirearm(FirearmCreate model)
        {
            var entity =
                new Firearm()
                {
                    OwnerId = _userId,
                    FirearmType = model.FirearmType,
                    CreatedBy = model.CreatedBy,
                    GunModel = model.GunModel,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new FirearmListItem
                            {
                                FirearmId = e.FirearmId,
                                FirearmType = e.FirearmType,
                                CreatedBy = e.CreatedBy,
                                GunModel = e.GunModel,
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
                       .Single(e => e.FirearmId == id && e.OwnerId == _userId);
                return
                    new FirearmDetails
                    {
                        FirearmType = entity.FirearmType,
                        Usage = entity.Usage,
                        FirearmId = entity.FirearmId,
                        CreatedBy = entity.CreatedBy,
                        GunModel = entity.GunModel,
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
                        .Single(e =>e.FirearmId == model.FirearmId && e.OwnerId == _userId);
                entity.CreatedBy = model.CreatedBy;
                entity.GunModel = model.GunModel;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Delete(int firearmId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Firearms
                        .Single(e => e.FirearmId == firearmId && e.OwnerId == _userId);
                ctx.Firearms.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}