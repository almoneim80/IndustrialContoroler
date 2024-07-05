using IndustrialContoroler.Resource;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
namespace IndustrialContoroler.ViewModel
{
    public class profileVM
    {
        public newPro NewPro { get; set; } = null!;
        public ChangePasswordProfileVM? ChangePasswordPf { get; set; } = null!;
        public class newPro { 
        public string? Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserFullName")]
        public string? FullName { get; set; }

        //[Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserName")]

        //public string UserName { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserEmail")]

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = null!;
        public string? ImageUser { get; set; } = null!;
    }
   }
}
