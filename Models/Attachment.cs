using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Attachment")]
    public partial class Attachment
    {
        [Key]
        [Column("at_Id")]
        public int AtId { get; set; }


        [Column("at_Url")]
        [Required(ErrorMessage = "يجب إدخال ملف المرفق")]
        public string AtUrl { get; set; } = null!;


        [Column("re_Id")]
        public int ReId { get; set; }


        [Column("att_Id")]
        public int AttId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("AttId")]
        [InverseProperty("Attachments")]
        [Required(ErrorMessage ="يجب تحديد نوع المرفق")]
        public virtual AttachmentType Att { get; set; } = null!;



        [ForeignKey("ReId")]
        [InverseProperty("Attachments")]
        public virtual Request Re { get; set; } = null!;
    }
}
