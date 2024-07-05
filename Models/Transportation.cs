using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("Transportation")]
    public partial class Transportation
    {
        [Key]
        [Column("tr_Id")]
        public int TrId { get; set; }


        [Column("tr_Type")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال نوع وسيلة النقل")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وسيله النقل عن حرفين")]
        public string TrType { get; set; } = null!;


        [Column("tr_plateNumber")]
        //[Required(ErrorMessage = "يرجى إدخال رقم لوحة وسيلة النقل")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? TrPlateNumber { get; set; }


        [Column("tr_Load")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال حمولة وسيلة النقل")]
        public string TrLoad { get; set; } = null!;


        [Column("tr_Notes")]
        public string? TrNotes { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }


        [ForeignKey("FaId")]
        [InverseProperty("Transportations")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
