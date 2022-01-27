using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Data
{
    public class Firearm
    {
        [Key]
        public int FirearmId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string FirearmType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Usage { get; set; } 
        [Required]
        public DateTimeOffset? LastCleaned { get; set; }


    }
}
