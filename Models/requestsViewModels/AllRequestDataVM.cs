using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models.requestsViewModels
{
    public class AllRequestDataVM
    {
        [Column("re_Type")]
        [Required(ErrorMessage = "يرجى تحديد نوع الطلب")]
        public string ReType { get; set; } = null!;


        [Column("re_Date", TypeName = "date")]
        [Required(ErrorMessage = "يرجى إدخال تاريخ الطلب")]
        public DateTime? ReDate { get; set; } = null!;



        [Column("re_formNo")]
        [Required(ErrorMessage = "يرجى إدخال رقم إستمارة الطلب")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم إستمارة طلب صحيح")]
        public int? ReFormNo { get; set; }


        [Column("re_suemNo")]
        [Required(ErrorMessage = "يرجى إدخال رقم سند الطلب")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم سند صحيح")]
        public int? ReSuemNo { get; set; }


        [Column("re_Applicant")]
        [Required(ErrorMessage = "يرجى إدخال اسم مقدم الطلب")]
        [MinLength(2, ErrorMessage = "يجب ان لا يقل اسم مقدم الطلب عن حرفين")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z\s]+$", ErrorMessage = "اسم مقدم الطلب لا يحب ان يحتوي على ارقام")]

        public string ReApplicant { get; set; } = null!;

        public virtual List<RequestAttVM> attachments { get; set; } = new List<RequestAttVM>();
    }
}
