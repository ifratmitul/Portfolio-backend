

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
            var project = await _context.Projects.ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(p => p.Id == request.Project.Id);
            Console.WriteLine(JsonSerializer.Serialize(project));

            if (project == null) return null;

            request.Project.Id = project.Id;
            request.Project.IsLive = project.IsLive;
            request.Project.Details = project.Details;
            request.Project.Rating = project.Rating;
            request.Project.Project_Url = project.Project_Url;
            request.Project.Title = project.Title;

            /*
            
            What to do if 1 or more skill Id is deleted
            
            
            */


            // _mapper.Map(request.Project, project);
            Console.WriteLine(JsonSerializer.Serialize(request.Project));

            return Result<Unit>.Success(Unit.Value);
        }

    }

}