namespace Domain;
public class MyProfile
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Highlight { get; set; }
    public string About { get; set; }
    public Photo Photo { get; set; }
    [NotMapped]
    public IFormFile Photofile { get; set; }
}