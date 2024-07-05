using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("secondaryAct")]
    public partial class SecondaryAct
    {
        [Key]
        [Column("sa_Id")]
        public int SaId { get; set; }


        [Column("sa_Name")]
        [StringLength(100)]
        public string? SaName { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("SecondaryActs")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
