using IndustrialContoroler.Resource;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class LoginVM
    {

        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RegisterName")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "Password")]
        [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
        [MinLength(5, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLengthPassword")]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
