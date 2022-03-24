namespace Domain;
public class Project
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public int Rating { get; set; }
    public bool IsLive { get; set; }
    public string Project_Url { get; set; }
    public ICollection<ProjectSkill> Skills { get; set; } = new List<ProjectSkill>();
    public ICollection<Photo> Photos { get; set; } = new List<Photo>();

    [NotMapped]
    public List<IFormFile> PhotoFiles { get; set; }
    [NotMapped]
    public List<Guid> SkillId { get; set; }

}
