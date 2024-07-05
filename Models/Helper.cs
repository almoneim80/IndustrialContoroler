namespace IndustrialContoroler.Models
{
    public class Helper
    {
        //image source
        public const string PathImageuser = "/images/Users/";
        public const string PathSaveImageuser = "images/Users/";
        public const int Timer = 10000;
        //Alert
        public const string Success = "success";
        public const string Error = "error";

        public const string MsgType = "msgType";
        public const string Title = "title";
        public const string Msg = "msg";
        public const string TitleEdit = " طلب تعديل";
        public const string TitleReject = "رفض الطلب";

        public const string Save = "Save";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string reference = "reference";
        public const string referenceFromTechToAdmin = "referencetoAdmin";
        public const string referenceToTechToEdit = "referencetotechToEdit";
        public const string RejectFieldVisit = "RejectFieldVisit";
        public const string AcceptFieldVisit = "AcceptFieldVisit";
        public const string referenceReToAdmin = "referenceReToAdmin";
        public const string RefernceReTotech = "RefernceReTotech";


        //permision

        public const string Edit = "تعديل";
        public const string View = "عرض";


        // Date Default User
        public const string FullNameAdmin = "اروى احمد الصليحي";
        public const string EmailAdmin = "Arwa@domin.com";
        public const string UserNameAdmin = "Arwa";
        public const string PasswordAdmin = "1234567";


        public const string FullNameProgrammer = "حربي احمد المنتصر محمد";
        public const string EmailProgrammer = "harbi@domin.com";
        public const string UserNameProgrammer = "harbi";
        public const string phoneProgrammer = "775147430";
        public const string image = "DefultImage.jpg";
        public const string PasswordProgrammer = "1234567";


        public const string FullNameTechnicalSpecialist = "محمد علي صالح اليريمي";
        public const string EmailTechnicalSpecialist = "mohammed@domin.com";
        public const string UserNameTechnicalSpecialist = "Mohammed";
        public const string PasswordTechnicalSpecialist = "1234567";

        public const string FullNameReEmp = "مشتاق محمد جابر ";
        public const string EmailReEmp = "mudhtag@domin.com";
        public const string UserNameReEmp = "mushtaq";
        public const string PasswordReEmp = "1234567";
        //الصلاحيات

        public const string Progreammer = "مبرمج النظام";
        public const string SysAdminsitrator = "مدير النظام";
        public const string SuperAdmin = "مدير عام ";
        public const string TechnicalSpecialist = "مختص فني";
        public const string ReEmployee = "موظف سجل ";



        public const string Permission = "Permission";
        //public enum Roles
        //{
        //    SysAdminsitrator,
        //    SuperAdmin,
        //    TechnicalSpecialist,
        //    ReEmployee
        //}

        public enum PermissionModuleName
        {
            Home,
            CreateFacility,
            Request,
            FieldVisitForms,
            Search,
            Reports,
            Charts,
            Statistics,
            Notification,
            Maps,
            Account,
            Roles,
            WorkFlowRequest,


        }

        public enum eCurrentState
        {
            Active = 1,
            Delete = 0
        }

    }
}
