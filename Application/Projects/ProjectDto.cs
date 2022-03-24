namespace Application.Projects;
public class ProjectDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public bool IsLive { get; set; }
    public string Project_Url { get; set; }
    public int Rating { get; set; }
    public List<ProjectSkillDto> Skills { get; set; } = new List<ProjectSkillDto>();
    public List<Photo> Photos { get; set; } = new List<Photo>();

}
