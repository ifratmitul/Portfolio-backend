using System;
using Domain;

namespace Application.Skills
{
    public class SkillDto
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public int Rating { get; set; }
        public string PhotoUrl { get; set; }
    }
}