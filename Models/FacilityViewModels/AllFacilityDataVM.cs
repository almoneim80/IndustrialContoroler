using IndustrialContoroler.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.ViewModel
{
    public class AllFacilityDataVM
    {

        //---------------- main data
        
        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يجب ان يكون رقم المنشأة أكبر من الصفر")]
        public int? FaNumber { get; set; }


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
        [Required(ErrorMessage = "يرجى إدخال النشاط الرئيسي للمنشأة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل النشاط عن ثلاثة حروف")]
        public string FaActivityType { get; set; } = null!;


        [Column("fa_mainActivity")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال النشاط الرئيسي للمنشأة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل النشاط عن ثلاثة حروف")]
        public string FaMainActivity { get; set; } = null!; //


        [Column("fa_shareCapital")]
        [Required(ErrorMessage = "يرجى إدخال مقدار رأس مال المنشأة")]
        [Range(1, Int64.MaxValue, ErrorMessage = "يرجى إدخال قيمة صحيحة لرأس المال")]
        public int FaShareCapital { get; set; }


        [Column("fa_startProduction", TypeName = "date")]
        [Required(ErrorMessage = "يرجى إدخال تاريخ بدء انتاج المنشأة")]
        public DateTime? FaStartProduction { get; set; }


        [Column("fa_totalArea")]
        [Required(ErrorMessage = "يرجى إدخال المساحة الكلية للمنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال قيمة صحيحة لمساحة المنشأة")]
        public int? FaTotalArea { get; set; }


        [Column("fa_Ownership")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد صفة ملكية المنشأة")]
        public string FaOwnership { get; set; } = null!;


        [Column("fa_workPeriods")]
        [Required(ErrorMessage = "يرجى إدخال عدد فترات العمل في المنشأة")]
        [Range(1, 10, ErrorMessage = "يرجى إدخال قيمة صحيحة لعدد فترات العمل")]
        public int? FaWorkPeriods { get; set; }


        [Column("fa_legalEntity")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال نوع الكيان القانوني للمنشأة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل نوع الكيان عن ثلاثة أحرف")]
        public string FaLegalEntity { get; set; } = null!;//


        [Column("fa_managerFName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاول لمدير المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaManagerFname { get; set; } = null!;//


        [Column("fa_managerMidName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاوسط لمدير المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaManagerMidName { get; set; } = null!;//


        [Column("fa_managerLName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاخير لمدير المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaManagerLname { get; set; } = null!;//


        [Column("fa_ownerFName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاوسط لمالك المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaOwnerFname { get; set; } = null!;//


        [Column("fa_ownerMidName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاخير لمالك المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaOwnerMidName { get; set; } = null!;//


        [Column("fa_ownerLName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم الاخير لمدير المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FaOwnerLname { get; set; } = null!;//


        [Column("fa_webSite")]
        [StringLength(100)]
        [Url(ErrorMessage = "يرجى إدخال عنوان موقع إلكتروني صحيح")]
        public string FaWebSite { get; set; }


        [Column("fa_Email")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "يرجى إدخال عنوان بريد إلكتروني صحيح")]
        public string FaEmail { get; set; }


        [Column("fa_faxNumber")]
        [StringLength(100)]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم فاكس صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم الفاكس عن 15 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الفاكس عن 9 ارقام")]
        public string FaFaxNumber { get; set; }


        [Column("fa_phoneNumber")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال رقم هاتف المنشأة")]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 15 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        public string FaPhoneNumber { get; set; }


        [Column("fa_mobileNumber")]
        [StringLength(100)]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم سيار صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم السيار عن 15 رقم")]
        [MinLength(7, ErrorMessage = "يجب ان لايقل رقم السيار عن 7 ارقام")]
        public string FaMobileNumber { get; set; }


        [Column("fa_Governorate")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المحافظة التي تقع فيها المنشأة")]
        public string FaGovernorate { get; set; } = null!;//


        [Column("fa_Directorate")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المديرية التي تقع فيها المنشأة")]
        [MinLength(2, ErrorMessage = "يرجى إدخال اسم مديرية لايقل عن حرفين")]
        public string FaDirectorate { get; set; } = null!;//


        [Column("fa_Address")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال عنوان المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال  عنوان لايقل عن ثلاثة حروف")]
        public string FaAddress { get; set; } = null!;//


        [Column("fa_regionName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المنطقة التي تقع فيها المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال  اسم منطقة لايقل عن  حرفين")]
        public string FaRegionName { get; set; } = null!;//


        [Column("fa_visitPurpose")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد الغرض من الزيارة الى المنشأة")]
        public string FaVisitPurpose { get; set; } = null!;//


        [Column("fa_visitDate", TypeName = "date")]
        [Required(ErrorMessage = "يرجى إدخال تاريخ الزيارة الى المنشأة")]
        public DateTime? FaVisitDate { get; set; }


        [Column("fa_dataState")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد حالة بيانات المنشأة")]
        public string FaDataState { get; set; } = null!;//

        //---------------- End Columns of Facility Table
        

        //---------------- Building Table
        [Column("bu_Ownership")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد ملكية المبنى")]
        public string BuOwnership { get; set; } = null!;


        [Column("bu_Description")]
        [Required(ErrorMessage = "يرجى إدخال وصف المبنى")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل الوصف عن ثلاثة حروف")]
        public string BuDescription { get; set; } = null!;


        [Column("bu_Type")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال نوعية البناء")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم النوع عن حرفين")]
        public string BuType { get; set; } = null!;


        [Column("bu_Length")]
        [Required(ErrorMessage = "يرجى إدخال طول المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال طول صحيح")]
        public int? BuLength { get; set; }


        [Column("bu_Width")]
        [Required(ErrorMessage = "يرجى إدخال عرض المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عرض صحيح")]
        public int? BuWidth { get; set; }


        [Column("bu_High")]
        [Required(ErrorMessage = "يرجى إدخال ارتفاع المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال ارتفاع صحيح")]
        public int? BuHigh { get; set; }


        [Column("bu_Area")]
        [Required(ErrorMessage = "يرجى إدخال مساحة المبنى")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال مساحة صحيحة")]
        public int? BuArea { get; set; }


        [Column("bu_Location")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال موقع المبنى")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم الموقع عن ثلاثة حروف")]
        public string BuLocation { get; set; } = null!;


        [Column("bu_Notes")]
        public string BuNotes { get; set; }


        [ForeignKey("Facility")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? BuFaNumber { get; set; }

        

        //جدول العمالة

        [Column("wo_Total")]
        [Required(ErrorMessage = "يرجى إدخال العدد الاجمالي للعمالة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoTotal { get; set; }


        [Column("wo_maleNumber")]
        [Required(ErrorMessage = "يرجى إدخال عدد الذكور ")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoMaleNumber { get; set; }



        [Column("wo_femaleNumber")]
        [Required(ErrorMessage = "يرجى إدخال عدد الإناث ")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? WoFemaleNumber { get; set; }



        [Column("wo_eduQualifying")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد المؤهل التعليمي")]
        public string WoEduQualifying { get; set; } = null!;



        [Column("wo_specialization")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم التخصص")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم التخصص عن حرفين")]
        public string WoSpecialization { get; set; } = null!;


        [Column("wo_Notes")]
        public string WoNotes { get; set; }


        [Column("fa_Number")]
        [ForeignKey("Facility")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? WFaNumber { get; set; }


        //جدول نوع العمالة
        [Column("wt_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال نوعية العمالة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم النوع عن ثلاثة حروف")]
        public string WtName { get; set; } = null!;


        //جدول الجنسية
        [Column("wn_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد جنسية العمالة")]

        public string WnName { get; set; } = null!;



        //جدول الالات والمعدات

        [Column("ma_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم الآلة")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الآلة عن حرفين")]
        public string MaName { get; set; }


        [Column("ma_number")]
        [Required(ErrorMessage = "يرجى إدخال عدد الآلات")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? MaNumber { get; set; }



        [Column("ma_Uses")]
        [Required(ErrorMessage = "يرجى إدخال إستخدامات الآلة")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم الاستخدام عن ثلاثة حروف")]
        public string MaUses { get; set; }



        [Column("ma_countryManufacture")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال بلد الصنع ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم البلد عن ثلاثة حروف")]
        public string MaCountryManufacture { get; set; }


        [Column("ma_measruingUnit")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string MaMeasruingUnit { get; set; }


        [Column("ma_Ability")]
        [Required(ErrorMessage = "يرجى إدخال القدرة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال عدد صحيح")]
        public int? MaAbility { get; set; }


        [Column("ma_Source")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد مصدر الآلة ")]
        public string MaSource { get; set; }


        [Column("ma_sourceAddress")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال عنوان المصدر ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم العنوان عن ثلاثة حروف")]
        public string MaSourceAddress { get; set; }


        [Column("ma_Notes")]
        public string MaNotes { get; set; }


        [Column("fa_Number")]
        [ForeignKey("Facility")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? MFaNumber { get; set; }


        //جدول المواد الخام

        [Column("rm_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المادة الخام")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المادة الخام عن حرفين")]
        public string RmName { get; set; }


        [Column("rm_measruingUnit")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string RmMeasruingUnit { get; set; }



        [Column("rm_amountUsed")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الكمية المستخدمة سنوياُ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string RmAmountUsed { get; set; }


        [Column("rm_percentInPro")]
        [Required(ErrorMessage = "يرجى إدخال النسبة المستخدمة في المنتج")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? RmPercentInPro { get; set; }


        [Column("rm_Source")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد مصدر المادة الخام ")]
        public string RmSource { get; set; }


        [Column("rm_Notes")]
        public string RmNotes { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? RFaNumber { get; set; }


        //جدول المواد المساعدة

        [Column("rm_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المادة المساعدة")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المادة المساعدة عن حرفين")]
        public string HmName { get; set; }


        [Column("rm_measruingUnit")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string HmMeasruingUnit { get; set; }



        [Column("rm_amountUsed")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الكمية المستخدمة سنوياُ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string HmAmountUsed { get; set; }


        [Column("rm_percentInPro")]
        [Required(ErrorMessage = "يرجى إدخال النسبة المستخدمة في المنتج")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? HmPercentInPro { get; set; }


        [Column("rm_Source")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد مصدر المادة المساعدة ")]
        public string HmSource { get; set; }


        [Column("rm_Notes")]
        public string HmNotes { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? HFaNumber { get; set; }



        //جدول وسائل النقل

        [Column("tr_Type")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال نوع وسيلة النقل")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وسيله النقل عن حرفين")]
        public string TrType { get; set; }


        [Column("tr_plateNumber")]
        [Required(ErrorMessage = "يرجى إدخال رقم لوحة وسيلة النقل")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public string TrPlateNumber { get; set; }  //change to string


        [Column("tr_Load")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال حمولة وسيلة النقل")]
        public string TrLoad { get; set; }


        [Column("tr_Notes")]
        public string TrNotes { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? TrFaNumber { get; set; }


        //جدول الوكلاء ونقاط البيع


        [Column("ap_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم الوكيل او نقطة البيع")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل الاسم عن حرفين")]
        public string ApName { get; set; }


        [Column("ap_tradeName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الاسم التجاري")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل الاسم التجاري عن حرفين")]
        public string ApTradeName { get; set; }


        [Column("ap_phoneNumber")]
        [Required(ErrorMessage = "يرجى إدخال رقم هاتف الوكيل او نقطة البيع")]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 15 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        public string ApPhoneNumber { get; set; }



        [Column("ap_Address")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال عنوان الوكيل او نقطة البيع")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل العنوان عن ثلاثة حروف")]
        public string ApAddress { get; set; }


        [Column("ap_Type")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى تحديد النوع")]
        public string ApType { get; set; }


        [Column("ap_Notes")]
        public string ApNotes { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? AFaNumber { get; set; }


        //جدول الطاقة الانتاجية

        [Column("pc_productName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المنتج")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المنتج عن حرفين")]
        public string PcProductName { get; set; }


        [Column("pc_yearQuantity")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال الكمية السنوية")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الكمية عن حرفين")]
        public string PcYearQuantity { get; set; }


        [Column("pc_measruingUnit")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم وحدة القياس ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم وحدة القياس عن حرفين")]
        public string PcMeasruingUnit { get; set; }


        [Column("pc_Notes")]
        public string PcNotes { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? PFaNumber { get; set; }


        //جدول وساءل الامن والسلامة

        [Column("ss_fireSystem")]
        public string SsFireSystem { get; set; }


        [Column("ss_emergencyExit")]
        public string SsEmergencyExit { get; set; }


        [Column("ss_occSafety")]
        public string SsOccSafety { get; set; }


        [Column("ss_safetyDashboard")]
        public string SsSafetyDashboard { get; set; }


        [Column("ss_Ventilation")]
        public string SsVentilation { get; set; }


        [Column("ss_Lighting")]
        public string SsLighting { get; set; }


        [Column("ss_firstAidKit")]
        public string SsFirstAidKit { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? SFaNumber { get; set; }



        //جدول وثائق الجهات المختصة
        [Column("rd_docName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم الوثيقة ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الوثيقة عن حرفين")]
        public string RdDocName { get; set; }


        [Column("rd_stakeholderName")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم الجهة ذات الصلة ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم الجهة عن ثلاثة حروف")]
        public string RdStakeholderName { get; set; }


        [Column("re_Description")]
        public string ReDescription { get; set; }

        [Required(ErrorMessage = "يرجى ادراج ملف الوثيقة ")]
        [Column("re_Url")]
        public string ReUrl { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int DoFaNumber { get; set; }


        //جدول المدلي بالبيان
        [Column("cd_Name")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال اسم المدلي ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم المدلي عن حرفين")]
        public string CdName { get; set; }


        [Column("cd_Job")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال وظيفة المدلي ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الوظيفة عن حرفين")]
        public string CdJob { get; set; }


        [Column("cd_phoneNumber")]
        [Required(ErrorMessage = "يرجى إدخال رقم هاتف المدلي")]
        [RegularExpression(@"^[0-9\+]*$", ErrorMessage = "يرجى إدخال رقم هاتف صحيح")]
        [MaxLength(15, ErrorMessage = "يجب ان لايزيد رقم الهاتف عن 15 رقم")]
        [MinLength(9, ErrorMessage = "يجب ان لايقل رقم الهاتف عن 9 ارقام")]
        public string CdPhoneNumber { get; set; }


        [Column("cd_idCardNumber")]
        [Required(ErrorMessage = "يرجى إدخال رقم بطاقة المدلي")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "يرجى إدخال رقم بطاقة صحيح")]
        [MaxLength(30, ErrorMessage = "يجب ان لايزيد رقم البطاقة عن 30 رقم")]
        public int? CdIdCardNumber { get; set; }


        [Column("cd_cardPlaceIssu")]
        [StringLength(100)]
        [Required(ErrorMessage = "يرجى إدخال مكان إصدار البطاقة ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم المكان عن ثلاثة حروف")]
        public string CdCardPlaceIssu { get; set; }


        [Column("cd_cardIssuDate", TypeName = "date")]
        [Required(ErrorMessage = "يرجى إدخال تاريخ البطاقة ")]
        public DateTime? CdCardIssuDate { get; set; }


        [Column("fa_Number")]
        [Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        [Compare("FaNumber", ErrorMessage = "يرجى إدخال رقم المنشأة الصحيح")]
        public int? CaFaNumber { get; set; }
        
    }
}
