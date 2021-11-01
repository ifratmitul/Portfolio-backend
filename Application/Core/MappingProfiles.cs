using Application.Experiences;
using Application.Skills;
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
            CreateMap<Skill, Skill>();
            CreateMap<Skill, SkillDto>()
            .ForMember(dto => dto.Id, source => source.MapFrom(m => m.Id))
            .ForMember(dto => dto.SkillName, source => source.MapFrom(m => m.SkillName))
            .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Photo.Url));

            CreateMap<Experience, Experience>();
            CreateMap<Experience, ExperienceDto>()
                .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Logo.Url));
        }
    }
}

