using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("helpMaterial")]
    public partial class HelpMaterial
    {
        [Key]
        [Column("hm_Id")]
        public int HmId { get; set; }


        [Column("hm_Name")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم المادة الخام")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المادة الخام عن حرفين")]
        public string HmName { get; set; } = null!;


        [Column("hm_measruingUnit")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string HmMeasruingUnit { get; set; } = null!;


        [Column("hm_amountUsed")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال الكمية المستخدمة سنوياُ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string HmAmountUsed { get; set; } = null!;


        [Column("hm_percentInPro")]
        //[Required(ErrorMessage = "يرجى إدخال النسبة المستخدمة في المنتج")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public double? HmPercentInPro { get; set; }


        [Column("hm_Source")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد مصدر المادة الخام ")]
        public string HmSource { get; set; } = null!;


        [Column("hm_Notes")]
        public string? HmNotes { get; set; }


        [Column("fa_Id")]
        public int FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("HelpMaterials")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
