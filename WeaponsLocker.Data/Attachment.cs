using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Data
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string AttachmentType { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string Usage { get; set; }

    }
}
