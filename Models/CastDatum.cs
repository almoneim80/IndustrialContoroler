using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("castData")]
    public partial class CastDatum
    {
        [Key]
        [Column("cd_Id")]
        public int? CdId { get; set; }



        [Column("cd_Name")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم المدلي ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المدلي عن حرفين")]
        public string CdName { get; set; } = null!;



        [Column("cd_Job")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال وظيفة المدلي ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الوظيفة عن حرفين")]
        public string CdJob { get; set; } = null!;



        [Column("cd_phoneNumber")]
        [StringLength(20)]
        //[Required(ErrorMessage = "يرجى إدخال رقم هاتف الوكيل او نقطة البيع")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح يتكون من ارقام فقط من 0-9")]
        [MaxLength(9, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 9 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        [Unicode(false)]
        public string? CdPhoneNumber { get; set; } = null!;



        [Column("cd_idCardNumber")]
        //[Required(ErrorMessage = "يرجى إدخال رقم بطاقة المدلي")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "يرجى إدخال رقم بطاقة صحيح يتكون من ارقام فقط من 0-9")]
        [MaxLength(11, ErrorMessage = "يجب ان لايزيد رقم البطاقة عن 11 رقم")]
        [MinLength(11, ErrorMessage = "يجب ان لايقل رقم البطاقة عن 11 رقم")]
        public string? CdIdCardNumber { get; set; } = null!;



        [Column("cd_cardPlaceIssu")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال مكان إصدار البطاقة ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم المكان عن ثلاثة حروف")]
        public string CdCardPlaceIssu { get; set; } = null!;



        [Column("cd_cardIssuDate", TypeName = "date")]
        //[Required(ErrorMessage = "يرجى إدخال تاريخ البطاقة ")]
        public DateTime? CdCardIssuDate { get; set; } = null!;



        [Column("fa_Id")]
        public int FaId { get; set; }



        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }



        [ForeignKey("FaId")]
        [InverseProperty("CastData")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
