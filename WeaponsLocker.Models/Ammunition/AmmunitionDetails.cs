using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Ammunition
{
    public class AmmunitionDetails
    {
        public int AmmoId { get; set; }
        public decimal Caliber { get; set; }
        public string ProjectileType { get; set; }
        public string Usage { get; set; }
    }

}
