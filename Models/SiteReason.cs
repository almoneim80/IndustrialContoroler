using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("siteReason")]
    public partial class SiteReason
    {
        [Key]
        [Column("sr_Id")]
        public int SrId { get; set; }


        [Column("sr_Reason")]
        [StringLength(100)]
        public string SrReason { get; set; } = null!;


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("SiteReasons")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
