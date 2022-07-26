namespace Domain
{
    public class EmployeeRegistrationModel 
    {
        public Guid? EmployeeId { get; set; }
        public Guid RoleId { get; set; }
        public string Email { get; set; }
        public string  Name { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
    }
}