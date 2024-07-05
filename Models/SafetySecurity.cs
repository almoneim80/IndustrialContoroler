using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("SafetySecurity")]
    public partial class SafetySecurity
    {
        [Key]
        [Column("ss_Id")]
        public int SsId { get; set; }


        [Column("ss_fireSystem")]
        [StringLength(10)]
        public string SsFireSystem { get; set; } = null!;


        [Column("ss_emergencyExit")]
        [StringLength(10)]
        public string SsEmergencyExit { get; set; } = null!;


        [Column("ss_occSafety")]
        [StringLength(10)]
        public string SsOccSafety { get; set; } = null!;


        [Column("ss_safetyDashboard")]
        [StringLength(10)]
        public string SsSafetyDashboard { get; set; } = null!;


        [Column("ss_Ventilation")]
        [StringLength(10)]
        public string SsVentilation { get; set; } = null!;


        [Column("ss_Lighting")]
        [StringLength(10)]
        public string SsLighting { get; set; } = null!;


        [Column("ss_firstAidKit")]
        [StringLength(10)]
        public string SsFirstAidKit { get; set; } = null!;


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("SafetySecurities")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
