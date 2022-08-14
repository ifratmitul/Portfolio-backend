namespace Domain
{
    public static class Permission
    {
        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permission.{module}.Create",
                $"Permission.{module}.View",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
            };
        }

        public static class Skill
        {
            public const string View = "Permissions.Skill.View";
            public const string Create = "Permissions.Skill.Create";
            public const string Edit = "Permissions.Skill.Edit";
            public const string Delete = "Permissions.Skill.Delete";
        }
         public static class Education
        {
            public const string View = "Permissions.Education.View";
            public const string Create = "Permissions.Education.Create";
            public const string Edit = "Permissions.Education.Edit";
            public const string Delete = "Permissions.Education.Delete";
        }
         public static class Project
        {
            public const string View = "Permissions.Project.View";
            public const string Create = "Permissions.Project.Create";
            public const string Edit = "Permissions.Project.Edit";
            public const string Delete = "Permissions.Project.Delete";
        }
         public static class Experience
        {
            public const string View = "Permissions.Experience.View";
            public const string Create = "Permissions.Experience.Create";
            public const string Edit = "Permissions.Experience.Edit";
            public const string Delete = "Permissions.Experience.Delete";
        }
    }
}