using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Data
{
    public enum FirearmType { Rifle, SniperRifle, Shotgun, Pistol}
    public enum Usage { EverydayCarry, HomeDefense, Hunting,}
    public class Firearm
    {
        [Key]
        public int FirearmId { get; set; }
        public enum FirearmType
        {
            Rifle,
            SniperRifle,
            Shotgun,
            Pistol,
        }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Model { get; set; }
        public enum Usage
        {
            EverydayCarry,
            HomeDefense,
            Hunting,
        }

        [Required]
        public DateTimeOffset? LastCleaned { get; set; }


    }
}
