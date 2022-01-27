using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Ammunition
{
    public class AmmunitionCreate
    {
        [Required]
        public decimal Caliber { get; set; }
        [Required]
        public string ProjectileType { get; set; }
        [Required]
        public string Usage { get; set; }
    }
}
