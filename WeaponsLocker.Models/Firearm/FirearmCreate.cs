using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Firearm
{
    public class FirearmCreate
    {
        [Required]
        public string FirearmType { get; set; }
        [Required]
        public string GunModel { get; set; }
        [Required]
        [Display (Name ="Created by")]
        public string CreatedBy { get; set; }
    }
}
