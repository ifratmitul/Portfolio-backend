using Application.Experiences;
using Application.PersonalInfo;
using Application.Projects;
using Application.Skills;
namespace Application.Core;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Education, Education>();
        CreateMap<Certificate, Certificate>();
        CreateMap<Skill, Skill>();
        CreateMap<Skill, SkillDto>()
        .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Photo.Url));
        CreateMap<Experience, Experience>();
        CreateMap<Experience, ExperienceDto>()
            .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Logo.Url));
        CreateMap<MyProfile, MyProfile>();
        CreateMap<MyProfile, ProfileDto>()
        .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Photo.Url));

        CreateMap<ProjectSkill, ProjectSkillDto>()
         .ForMember(dto => dto.SkillName, s => s.MapFrom(m => m.SKill.SkillName))
         .ForMember(dto => dto.PhotoUrl, s => s.MapFrom(m => m.SKill.Photo.Url));

        CreateMap<Project, ProjectDto>()
        .ForMember(dto => dto.Photos, s => s.MapFrom(m => m.Photos))
        .ForMember(dto => dto.Skills, s => s.MapFrom(m => m.Skills));

    }
}