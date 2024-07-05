using IndustrialContoroler.Resource;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class ChangePasswordVM
    {

        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "oldPassword")]
        public string? OldPassword { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "Password")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(5, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLengthPassword")]
        public string NewPassword { get; set; } = null!;


        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "ComparePassword")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "ComparePasswordError")]
        public string ComparePassword { get; set; } = null!;
    }
}
