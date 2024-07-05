using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace IndustrialContoroler.Models.FacilityViewModels
{
    public class FacilityMainDataVM
    {
        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب ان يكون رقم المنشأة أكبر من الصفر")]
        public int? FaNumber { get; set; }


        [Column("re_formNo")]
        [Required(ErrorMessage = "يرجى تحديد رقم إستمارة الطلب")]
        //[Range(1, int.MaxValue, ErrorMessage = "يجب ان يكون رقم إستمارة الطلب أكبر من الصفر")]
        public int? ReFormNo { get; set; }


        [Column("fa_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المنشأة")]
        [MinLength(2, ErrorMessage = "يجب ادخال اسم منشأة لايقل عن حرفين")]
        public string FaName { get; set; } = null!;


        [Column("fa_Size")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد حجم المنشأة")]
        public string FaSize { get; set; } = null!;


        [Column("fa_activityType")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد  نوع نشاط المنشأة")]
        public string FaActivityType { get; set; } = null!;


        [Column("fa_mainActivity")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال النشاط الرئيسي للمنشأة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل النشاط عن ثلاثة حروف")]
        public string FaMainActivity { get; set; } = null!;


        [Column("fa_shareCapital")]
        [Required(ErrorMessage = "يرجى إدخال مقدار رأس مال المنشأة")]
        public string FaShareCapital { get; set; } = null!;


        [Column("fa_startProduction", TypeName = "date")]
        [Required(ErrorMessage = "يرجى إدخال تاريخ بدء انتاج المنشأة")]
        public DateTime? FaStartProduction { get; set; }


        [Column("fa_totalArea")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال المساحة الكلية للمنشأة")]
        public string FaTotalArea { get; set; } = null!;


        [Column("fa_Ownership")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد صفة ملكية المنشأة")]
        public string FaOwnership { get; set; } = null!;


        [Column("fa_workPeriods")]
        [Required(ErrorMessage = "يرجى إدخال عدد فترات العمل في المنشأة")]
        [Range(1, 5, ErrorMessage = "يرجى إدخال قيمة صحيحة لعدد فترات العمل")]
        public int? FaWorkPeriods { get; set; }



        [Column("fa_legalEntity")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال نوع الكيان القانوني للمنشأة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل نوع الكيان عن ثلاثة أحرف")]
        public string FaLegalEntity { get; set; } = null!;



        [Column("fa_ManagerName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم  مدير المنشأة")]
        [MinLength(2, ErrorMessage = "يرجى إدخال اسم لايقل عن حرفين")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaManagerName { get; set; } = null!;


        [Column("fa_OwnerName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم  مالك المنشأة")]
        [MinLength(2, ErrorMessage = "يرجى إدخال اسم لايقل عن حرفين")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaOwnerName { get; set; } = null!;



        [Column("fa_Mode")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد وضع المنشأة")]
        public string FaMode { get; set; } = null!;




        //-----------------------------------------------التواصل
        [Column("fa_webSite")]
        [StringLength(100)]
        [Url(ErrorMessage = "يرجى إدخال عنوان موقع إلكتروني صحيح")]
        public string? FaWebSite { get; set; }


        [Column("fa_Email")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "يرجى إدخال عنوان بريد إلكتروني صحيح")]
        public string? FaEmail { get; set; }


        [Column("fa_faxNumber")]
        [StringLength(100)]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم فاكس صحيح")]
        [MaxLength(9, ErrorMessage = "يجب ان لايزيد رقم الفاكس عن 9 ارقام")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الفاكس عن 9 ارقام")]
        public string? FaFaxNumber { get; set; }


        [Column("fa_phoneNumber")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال رقم هاتف المنشأة")]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم سيار صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم السيار عن 15 رقم")]
        [MinLength(7, ErrorMessage = "يجب ان لايقل رقم السيار عن 7 ارقام")]
        public string? FaPhoneNumber { get; set; } = null!;



        [Column("fa_mobileNumber")]
        [StringLength(100)]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 15 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        public string? FaMobileNumber { get; set; }





        //-------------------------------------الموقع
        [Column("fa_Governorate")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد المحافظة التي تقع فيها المنشأة")]
        public string FaGovernorate { get; set; } = null!;



        [Column("fa_Directorate")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المديرية التي تقع فيها المنشأة")]
        [MinLength(2, ErrorMessage = "يرجى إدخال اسم مديرية لايقل عن حرفين")]
        public string FaDirectorate { get; set; } = null!;



        [Column("fa_Address")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال عنوان المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال  عنوان لايقل عن ثلاثة حروف")]
        public string FaAddress { get; set; } = null!;


        [Column("fa_regionName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المنطقة التي تقع فيها المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال  اسم منطقة لايقل عن  حرفين")]
        public string FaRegionName { get; set; } = null!;
        public virtual List<SiteReason> Reasons { get; set; } = new List<SiteReason>();
        public virtual List<SecondaryAct> secondaryActs { get; set; } = new List<SecondaryAct>();
    }
}
