using Microsoft.AspNetCore.Identity;
namespace Domain;

public class AppAdmin : IdentityUser
{
    public string Name { get; set; }
    public string AccessType { get; set; }
    public string Designation { get; set; }
}
