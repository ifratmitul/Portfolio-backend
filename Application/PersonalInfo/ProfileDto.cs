using System;

namespace Application.PersonalInfo
{
    public class ProfileDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Highlight { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }
    }
}