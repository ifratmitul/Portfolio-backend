using System;

namespace Domain
{
    public class ProjectSkill
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid SkillId { get; set; }
        public Skill SKill { get; set; }
    }
}