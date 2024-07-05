using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndustrialContoroler.Models
{
    [Table("agentsPoint")]
    public partial class AgentsPoint
    {
        [Key]
        [Column("ap_Id")]
        public int ApId { get; set; }


        [Column("ap_Name")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم الوكيل او نقطة البيع")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل الاسم عن حرفين")]
        public string ApName { get; set; } = null!;


        [Column("ap_tradeName")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال الاسم التجاري")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل الاسم التجاري عن حرفين")]
        public string ApTradeName { get; set; } = null!;



        [Column("ap_phoneNumber")]
        [StringLength(20)]
        //[Required(ErrorMessage = "يرجى إدخال رقم هاتف الوكيل او نقطة البيع")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح يتكون من ارقام فقط من 0-9")]
        [MaxLength(9, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 9 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        [Unicode(false)]
        public string ApPhoneNumber { get; set; } = null!;



        [Column("ap_Address")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال عنوان الوكيل او نقطة البيع")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل العنوان عن ثلاثة حروف")]
        public string ApAddress { get; set; } = null!;



        [Column("ap_Type")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى تحديد النوع")]
        public string ApType { get; set; } = null!;


        [Column("ap_Notes")]
        public string? ApNotes { get; set; } 


        [Column("fa_Id")]
        //[Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? FaId { get; set; }


        [Column("Is_Deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey("FaId")]
        [InverseProperty("AgentsPoints")]
        public virtual Facility Fa { get; set; } = null!;
    }
}
