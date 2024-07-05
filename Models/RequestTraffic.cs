using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("requestTraffic")]
    public partial class RequestTraffic
    {

        [Key]
        [Column("rt_Id")]
        public int RtId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        [Column("re_Id")]
        public int ReId { get; set; }

        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey("ReId")]
        [InverseProperty("RequestTraffics")]
        public virtual Request Re { get; set; } = null!;
        

    }
}
