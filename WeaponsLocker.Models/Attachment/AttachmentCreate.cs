using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Attachment
{
    public class AttachmentCreate
    {
        [Required]
        public string AttachmentType { get; set; }
        [ForeignKey(nameof(Firearm))]
        public string CreatedBy { get; set; }
        [Required]
        public string Usage { get; set; }
    }
}
