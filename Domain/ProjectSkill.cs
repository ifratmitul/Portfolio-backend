namespace Domain;
public class ProjectSkill
{
    public Guid ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
    public Guid SkillId { get; set; }
    [ForeignKey("SkillId")]
    public Skill SKill { get; set; }
}
