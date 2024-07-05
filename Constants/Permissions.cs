using static IndustrialContoroler.Models.Helper;

namespace IndustrialContoroler.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsFromModule(string module)
        {
            return new List<string>
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }
        public static List<string> PermissionsList()
        {
            var allPermissions = new List<string>();

            foreach (var module in Enum.GetValues(typeof(PermissionModuleName)))
                allPermissions.AddRange(GeneratePermissionsFromModule(module.ToString()));
            return allPermissions;
        }

        public static class Home
        {
            public const string View = "Permissions.Home.View";
            public const string Create = "Permissions.Home.Create";
            public const string Edit = "Permissions.Home.Edit";
            public const string Delete = "Permissions.Home.Delete";

        }

        public static class CreateFacility
        {
            public const string View = "Permissions.CreateFacility.View";
            public const string Create = "Permissions.CreateFacility.Create";
            public const string Edit = "Permissions.CreateFacility.Edit";
            public const string Delete = "Permissions.CreateFacility.Delete";

        }

        public static class Request
        {
            public const string View = "Permissions.Request.View";
            public const string Create = "Permissions.Request.Create";
            public const string Edit = "Permissions.Request.Edit";
            public const string Delete = "Permissions.Request.Delete";

        }

        public static class FieldVisitForms
        {
            public const string View = "Permissions.FieldVisitForms.View";
            public const string Create = "Permissions.FieldVisitForms.Create";
            public const string Edit = "Permissions.FieldVisitForms.Edit";
            public const string Delete = "Permissions.FieldVisitForms.Delete";

        }

        public static class Search
        {
            public const string View = "Permissions.Search.View";
            public const string Create = "Permissions.Search.Create";
            public const string Edit = "Permissions.Search.Edit";
            public const string Delete = "Permissions.Search.Delete";

        } 
        public static class Reports
        {
            public const string View = "Permissions.Reports.View";
            public const string Create = "Permissions.Reports.Create";
            public const string Edit = "Permissions.Reports.Edit";
            public const string Delete = "Permissions.Reports.Delete";

        }
        public static class Charts
        {
            public const string View = "Permissions.Charts.View";
            public const string Create = "Permissions.Charts.Create";
            public const string Edit = "Permissions.Charts.Edit";
            public const string Delete = "Permissions.Charts.Delete";

        }
        
        public static class Statistics
        {
            public const string View = "Permissions.Statistics.View";
            public const string Create = "Permissions.Statistics.Create";
            public const string Edit = "Permissions.Statistics.Edit";
            public const string Delete = "Permissions.Statistics.Delete";

        }

        public static class WorkFlowRequest
        {
            public const string View = "Permissions.WorkFlowRequest.View";
            public const string Create = "Permissions.WorkFlowRequest.Create";
            public const string Edit = "Permissions.WorkFlowRequest.Edit";
            public const string Delete = "Permissions.WorkFlowRequest.Delete";

        } 
        public static class Notification
        {
            public const string View = "Permissions.Notification.View";
            public const string Create = "Permissions.Notification.Create";
            public const string Edit = "Permissions.Notification.Edit";
            public const string Delete = "Permissions.Notification.Delete";

        }
        
        public static class Maps
        {
            public const string View = "Permissions.Maps.View";
            public const string Create = "Permissions.Maps.Create";
            public const string Edit = "Permissions.Maps.Edit";
            public const string Delete = "Permissions.Maps.Delete";

        }

        public static class Account
        {
            public const string View = "Permissions.Account.View";
            public const string Create = "Permissions.Account.Create";
            public const string Edit = "Permissions.Account.Edit";
            public const string Delete = "Permissions.Account.Delete";

        }

        public static class Roles
        {
            public const string View = "Permissions.Roles.View";
            public const string Create = "Permissions.Roles.Create";
            public const string Edit = "Permissions.Roles.Edit";
            public const string Delete = "Permissions.Roles.Delete";

        }
       

    }
}
