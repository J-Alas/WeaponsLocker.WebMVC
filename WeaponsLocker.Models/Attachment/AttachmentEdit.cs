using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Attachment
{
    public  class AttachmentEdit
    {
        public int AttachmentId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        public string AttachmentType { get; set; }
        public string CreatedBy { get; set; }
        public string Usage { get; set; }
    }
}
