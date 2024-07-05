using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("attachmentType")]
    public partial class AttachmentType
    {
        public AttachmentType()
        {
            Attachments = new HashSet<Attachment>();
        }

        [Key]
        [Column("att_Id")]
        public int AttId { get; set; }


        [Column("att_attachmentName")]
        [StringLength(100)]
        public string AttAttachmentName { get; set; } = null!;


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [InverseProperty("Att")]
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
