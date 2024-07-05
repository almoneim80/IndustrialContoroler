

using IndustrialContoroler.Resource;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class RoleVM
    {
        public List<IdentityRole>? Roles { get; set; }
        public NewRole NewRole { get; set; } = null!;
    }
    public class NewRole
    {
        public string? RoleId { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RoleName")]
        [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z\s]+$", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "notacceptNumber")]
        public string RoleName { get; set; } = null!;
    }
}
