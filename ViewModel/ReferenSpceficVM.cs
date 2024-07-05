using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class ReferenSpceficVM
    {
        [Required(ErrorMessage = "يرجى  تحديد الوجهة المراد التواصل بها")]
        public string? RoleId { get; set; } = null!;
        [Required(ErrorMessage = "يرجى  تحديدالمستخدم")]
        public string? ToUserId { get; set; } = null!;
    }
}
