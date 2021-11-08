using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public ICollection<ProjectSkill> Skills { get; set; } = new List<ProjectSkill>();
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();

        [NotMapped]
        public List<IFormFile> PhotoFiles { get; set; }
        [NotMapped]
        public List<Guid> SkillId { get; set; }

    }
}