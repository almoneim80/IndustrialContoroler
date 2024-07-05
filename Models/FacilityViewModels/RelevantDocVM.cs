using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndustrialContoroler.Models.FacilityViewModels
{
    public class RelevantDocVM
    {
        [Key]
        [Column("rd_Id")]
        public int? RdId { get; set; }


        [Column("rd_docName")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم الوثيقة ")]
        [MinLength(2, ErrorMessage = "يجب ان لايقل اسم الوثيقة عن حرفين")]
        public string RdDocName { get; set; } = null!;



        [Column("rd_stakeholderName")]
        [StringLength(100)]
        //[Required(ErrorMessage = "يرجى إدخال اسم الجهة ذات الصلة ")]
        [MinLength(3, ErrorMessage = "يجب ان لايقل اسم الجهة عن ثلاثة حروف")]
        public string RdStakeholderName { get; set; } = null!;



        [Column("re_Description")]
        public string ReDescription { get; set; } = null!;


        [Column("re_Url")]
        //[Required(ErrorMessage = "يرجى ادراج ملف الوثيقة ")]
        public IFormFile ReFile { get; set; } = null!;


        [Column("fa_Id")]
        //[Required(ErrorMessage = "يرجى إدخال رقم المنشأة")]
        [Range(1, int.MaxValue, ErrorMessage = "يرجى إدخال رقم صحيح")]
        public int? FaId { get; set; }
    }
}
