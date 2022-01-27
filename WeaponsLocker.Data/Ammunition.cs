using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Data
{
    public class Ammunition
    {
        [Key]
        public int AmmoId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public decimal Caliber { get; set; }
        [Required]
        public string ProjectileType { get; set; }

        [Required]
        public string Usage { get; set; }
    }
}
