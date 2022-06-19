namespace Application.Projects;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Project Project { get; set; }
    }

    public class ProjectEditHandler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ProjectEditHandler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _context = context;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {

            Project project = await _context.Projects
                                        .Include(p => p.Skills)
                                        .Include(p => p.Photos)
                                        .Where(p => p.Id == request.Project.Id)
                                        .FirstOrDefaultAsync();

            if (project == null) return null;

            if (request.Project.SkillId != null)
            {
                List<Guid> existingSkills = project.Skills.Select(s => s.SkillId).ToList();
                List<Guid> newSkillIds = new List<Guid>();

                if (existingSkills != null)
                {
                    newSkillIds = request.Project.SkillId.Where(id => !existingSkills.Contains(id)).ToList();
                }

                foreach (Guid id in newSkillIds)
                {
                    Skill skill = await _context.Skills.FindAsync(id);
                    if (skill == null) return Result<Unit>.Failure("Coudln't find the Skill in Database");

                    var newProjectSkill = new ProjectSkill { ProjectId = project.Id, SkillId = skill.Id };
                    project.Skills.Add(newProjectSkill);
                }
            }

            if (request.Project.PhotoFiles != null)
            {
                foreach (IFormFile item in request.Project.PhotoFiles)
                {
                    var photoResult = await _photoAccessor.AddPhoto(item);
                    if (photoResult == null) return Result<Unit>.Failure("Failed to upload photo");

                    var photo = new Photo
                    {
                        Id = photoResult.PublicId,
                        Url = photoResult.Url,
                        IsMain = request.Project.Photos.Count <= 0 ? true : false,
                    };
                    project.Photos.Add(photo);

                }
            }

            project.Title = request.Project.Title ?? project.Title;
            project.Details = request.Project.Details ?? project.Details;
            project.Project_Url = request.Project.Project_Url ?? project.Project_Url;
            project.IsLive = request.Project.IsLive;
            project.Rating = request.Project.Rating;

            var result = await _context.SaveChangesAsync() > 0;
            if (result)
                return Result<Unit>.Success(Unit.Value);

            return Result<Unit>.Failure("Failed save changes while editing Project");
        }
    }

}