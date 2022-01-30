using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
        public Photo Photo { get; set; }

    }

}