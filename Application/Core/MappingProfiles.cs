using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Education, Education>();
            CreateMap<Certificate, Certificate>();
        }
    }
}