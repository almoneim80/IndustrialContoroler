
using IndustrialContoroler.Models;
using IndustrialContoroler.Resource;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IndustrialContoroler.ViewModel
{
    public class UserVM
    {

        public List<VwUser>? Users { get; set; }
        public List<IdentityRole>? Roles { get; set; }
        public NewRegister newRegister { get; set; } = null!;

        public ChangePasswordVM? ChangePassword { get; set; }
        public class NewRegister
        {
            public string? Id { get; set; }
            [MinLength(3, ErrorMessage = "يرجى إدخال اسم لايقل عن ثلاثة حروف")]
            [RegularExpression(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z\s]+$", ErrorMessage="اسم الموضف لا يحب ان يحتوي على ارقام")]
            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserFullName")]
            public string FullName { get; set; } = null!;
            [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "اسم المستخدم يجب ان يحتوي على احرف انجليزيه ")]

            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserName")]

            public string UserName { get; set; } = null!;

            [EmailAddress]
            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "UserEmail")]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9._%+-]+\.[a-zA-Z0-9]{2,}$", ErrorMessage = "يرجى إدخال عنوان بريد إلكتروني صحيح")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RoleName")]
            public string RoleName { get; set; } = string.Empty;
            [StringLength(100)]
           
           
           
            [MaxLength(9, ErrorMessage = "يجب ان لايزيد رقم السيار عن 9 رقم")]
            [MinLength(9, ErrorMessage = "يجب ان لايقل رقم السيار عن 9 ارقام")]
            [RegularExpression(@"^7[0-9]*$", ErrorMessage = "يجب إن يبداء رقم السيار ب 7")]
            public string PhoneNumber { get; set; } = null!;
            [RegularExpression(@"^.*\.(jpg|jpeg|png|PNG|JPG|JPEG)$", ErrorMessageResourceType = typeof(ResourceWeb), ErrorMessageResourceName = "notaccepfileNoImage")]
            public string? ImageUser { get; set; } = null!; 
            public bool ActiveUser { get; set; }



            [DataType(DataType.Password)]
            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "Password")]
            [MaxLength(20, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MaxLength")]
            [MinLength(5, ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "MinLengthPassword")]
            public string Password { get; set; } = String.Empty;
            [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "Passwordconfirm")]
            [DataType(DataType.Password)]
            //[Compare("Password", ErrorMessage = "passwords not matches")]
            [Compare("Password", ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "ComparePasswordError")]

            public string ConfirmPassword { get; set; } = null!;



        }

    }

}
