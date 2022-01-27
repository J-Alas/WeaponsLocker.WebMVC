using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Firearm
{
    public class FirearmListItem
    {
        public string FirearmType { get; set; }
        public string Usage { get; set; }
        public int FirearmId { get; set; }
        [Display(Name ="Created by")]
        public string CreatedBy { get; set; }
        public string GunModel { get; set; }
        [Display(Name ="Cleaned on")]
        public DateTimeOffset? LastCleaned { get; set; }
        
    }
}

