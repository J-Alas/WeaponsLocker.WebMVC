using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Firearm
{
    public class FirearmDetails
    {
        public enum FirearmType { Rifle, SniperRifle, Shotgun, Pistol }
        public enum Usage { EverydayCarry, HomeDefense, Hunting, }
        public int FirearmId { get; set; }
        public string CreatedBy { get; set; }
        public string Model { get; set; }
        public DateTimeOffset? LastCleaned { get; set; }
    }
}
