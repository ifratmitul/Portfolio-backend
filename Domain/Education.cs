namespace Domain;
public class Education
{
    public Guid Id { get; set; }
    public string Institution { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Degree { get; set; }
    public string Major { get; set; }
    public double Result { get; set; }
    public int Priority { get; set; }
    public Photo Logo { get; set; }
    [NotMapped]
    public IFormFile PhotoFile { get; set; }
}
