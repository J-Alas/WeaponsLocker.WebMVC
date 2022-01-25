using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Ammunition
{
    public class AmmunitionListItem
    {
        public int Id { get; set; }
        public decimal Caliber { get; set; }
        public string ProjectileType { get; set; }
        public enum Usage
        {
            EverydayCarry,
            HomeDefense,
            Hunting,
        }
    }
}
