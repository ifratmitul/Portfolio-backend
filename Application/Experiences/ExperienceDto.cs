using System;

namespace Application.Experiences
{
    public class ExperienceDto
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Responsibilities { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}