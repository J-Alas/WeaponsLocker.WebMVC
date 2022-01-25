using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLocker.Models.Attachment
{
    public class AttachmentListItem
    {
        public int AttachmentId { get; set; }
        public string AttachmentType { get; set; }
        public string CreatedBy { get; set; }
        public enum Usage { EverydayCarry, HomeDefense, Hunting }
    }
}
