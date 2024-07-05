using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("rowMaterial")]
    public partial class RowMaterial
    {
        [Key]
        [Column("rm_Id")]
        public int RmId { get; set; }


        [Column("rm_Name")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم المادة الخام")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المادة الخام عن حرفين")]
        public string RmName { get; set; } = null!;


        [Column("rm_measruingUnit")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string RmMeasruingUnit { get; set; } = null!;


        [Column("rm_amountUsed")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال الكمية المستخدمة سنوياُ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string RmAmountUsed { get; set; } = null!;


        [Column("rm_percentInPro")]
        //[Required(ErrorMessage = "يرجى إدخال النسبة المستخدمة في المنتج")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public double? RmPercentInPro { get; set; }


        [Column("rm_Source")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد مصدر المادة الخام ")]
        public string RmSource { get; set; } = null!;


        [Column("rm_Notes")]
        public string? RmNotes { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("RowMaterials")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
