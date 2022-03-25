namespace Application.Certificates;

public class CertificateDto
{

    public Guid Id { get; set; }
    public string name { get; set; }
    public DateTime Date { get; set; }
    public string Provider { get; set; }
    public int Priority { get; set; }
    public Photo Logo { get; set; }
    public string Url { get; set; }

}
