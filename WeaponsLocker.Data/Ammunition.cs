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
        public int Id { get; set; }
        [Required]
        public decimal Caliber { get; set; }
        [Required]
        public string ProjectileType { get; set; }
        public enum Usage
        {
            EverydayCarry,
            HomeDefense,
            Hunting,
        }
    }
}
