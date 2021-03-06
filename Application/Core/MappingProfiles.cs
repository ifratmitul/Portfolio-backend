using Application.Experiences;
using Application.PersonalInfo;
using Application.Projects;
using Application.Skills;
namespace Application.Core;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        #region EditMappingRegion
        CreateMap<Education, Education>();
        CreateMap<Certificate, Certificate>();
        CreateMap<Skill, Skill>();
        CreateMap<Experience, Experience>();
        CreateMap<MyProfile, MyProfile>();
        #endregion

        CreateMap<Skill, SkillDto>()
        .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Photo.Url));
      
        CreateMap<Experience, ExperienceDto>()
            .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Logo.Url));
     
        CreateMap<MyProfile, ProfileDto>()
        .ForMember(dto => dto.PhotoUrl, source => source.MapFrom(m => m.Photo.Url));

        CreateMap<ProjectSkill, ProjectSkillDto>()
         .ForMember(dto => dto.Id, s => s.MapFrom(m => m.SKill.Id))
         .ForMember(dto => dto.SkillName, s => s.MapFrom(m => m.SKill.SkillName))
         .ForMember(dto => dto.PhotoUrl, s => s.MapFrom(m => m.SKill.Photo.Url));

        CreateMap<Project, ProjectDto>()
        .ForMember(dto => dto.Photos, s => s.MapFrom(m => m.Photos))
        .ForMember(dto => dto.Skills, s => s.MapFrom(m => m.Skills));

        CreateMap<Education, Schools.EducationDto>()
        .ForMember(dto => dto.Logo, s => s.MapFrom(e => e.Logo));

        CreateMap<Certificate, Certificates.CertificateDto>()
        .ForMember(dto => dto.Logo, s => s.MapFrom(e => e.Logo));

    }
}