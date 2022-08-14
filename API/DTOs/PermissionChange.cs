namespace API.DTOs
{
    public class PermissionChange
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
