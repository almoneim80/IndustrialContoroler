using IndustrialContoroler.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class NotificationVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يرجى إدخال عنوان الأشعار")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "يرجى إدخال وصف الأشعار")]
        public string Description { get; set; } = null!;
        public string? FacilityId { get; set; }
        [Required(ErrorMessage = "يرجى  تحديد الوجهة المراد التواصل بها")]
        public string RoleId { get; set; } = null!;
        [Required(ErrorMessage = "يرجى  تحديدالمستخدم")]
        public string ToUserId { get; set; } = null!;
        
        public string? Filter { get; set; } 
    }
}
