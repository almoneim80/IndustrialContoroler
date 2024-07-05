using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("visitsTraffic")]
    public partial class VisitsTraffic
    {
        [Key]
        [Column("vt_Id")]
        public int? VtId { get; set; }


        [Column("vt_visitDate", TypeName = "date")]
        public DateTime? VtVisitDate { get; set; } = null!;


        [Column("vt_visitPurpose")]
        [StringLength(100)]
        public string VtVisitPurpose { get; set; } = null!;


        [Column("re_formNo")]
        public int? ReFormNo { get; set; }


        [Column("fa_Id")]
        public int? FaId { get; set; }


        [Column("fa_dataState")]
        [StringLength(100)]
        public string? FaDataState { get; set; } = null!;


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("VisitsTraffics")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
