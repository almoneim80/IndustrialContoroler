using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.Models
{
    public class AppUsers : IdentityUser
    {

        [Required(ErrorMessage = "يرجى إدخال اسم  مدير المنشأة")]
        [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
        [DataType(DataType.Text, ErrorMessage = "لايمكن ان يحتوي الاسم على ارقام او رموز")]
        public string FullName { get; set; } = null!;

        public bool ActiveUser { get; set; }

        public string? ImageUser { get; set; }
    }
}
