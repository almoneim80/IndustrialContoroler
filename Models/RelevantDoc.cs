using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("relevantDoc")]
    public partial class RelevantDoc
    {
        [Key]
        [Column("rd_Id")]
        public int RdId { get; set; }


        [Column("rd_docName")]
        [StringLength(100)]
        public string RdDocName { get; set; } = null!;


        [Column("rd_stakeholderName")]
        [StringLength(100)]
        public string RdStakeholderName { get; set; } = null!;


        [Column("re_Description")]
        public string? ReDescription { get; set; }


        [Column("re_Url")]
        public string ReUrl { get; set; } = null!;


        [Column("fa_Id")]
        public int? FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("RelevantDocs")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
