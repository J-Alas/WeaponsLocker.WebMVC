using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Attachment
{
    public class AttachmentDetails
    {
        public int AttachmentId { get; set; }
        public string AttachmentType { get; set; }
        public string CreatedBy { get; set; }
        public enum Usage { EverydayCarry, HomeDefense, Hunting }
    }
}
