namespace Domain;
public class Blog
{
    public Guid Id { get; set; }
    public string Blog_title { get; set; }
    public string Blog_article { get; set; }
    public Photo BlogCoverPhoto { get; set; }
    public DateOnly DateOfPublish  { get; set; }


}

