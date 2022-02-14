namespace Domain;
public class Experience
{
    public Guid Id { get; set; }
    public string Company { get; set; }
    public string Position { get; set; }
    public string Responsibilities { get; set; }
    public Photo Logo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [NotMapped]
    public IFormFile PhotoFile { get; set; }
}
