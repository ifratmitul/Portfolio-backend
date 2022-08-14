namespace Domain
{
    public class EmployeeRole
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
    }

    public enum Roles {
        SuperAdmin,
        Admin,
        Moderator,
        Editor,
        Basic
    }
}
