namespace Application.Projects;
public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Project Project { get; set; }

    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(DataContext context, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.Project.PhotoFiles.Count <= 0) return Result<Unit>.Failure("File Missing");
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
                request.Project.Photos.Add(photo);

            }

            if (request.Project.SkillId.Count <= 0) return Result<Unit>.Failure("No Skill ID added here");
            foreach (Guid item in request.Project.SkillId)
            {
                var SkillResult = await _context.Skills.FindAsync(item);
                if (SkillResult == null) return Result<Unit>.Failure("Failed find skill");

                var projectSkill = new ProjectSkill
                {
                    SKill = SkillResult,
                    Project = request.Project
                };

                request.Project.Skills.Add(projectSkill);
            }

            _context.Projects.Add(request.Project);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Result<Unit>.Success(Unit.Value);
            return Result<Unit>.Failure("Failed to add Project");

        }
    }

}
