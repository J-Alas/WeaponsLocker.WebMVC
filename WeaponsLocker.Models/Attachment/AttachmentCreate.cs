using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Attachment
{
    public class AttachmentCreate
    {
        public string AttachmentType { get; set; }
        public string CreatedBy { get; set; }
        public string Usage { get; set; }
    }
}
