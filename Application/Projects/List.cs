namespace Application.Projects;

public class List
{
    public class Query : IRequest<Result<List<ProjectDto>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<ProjectDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<ProjectDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var projects = await _context.Projects.ProjectTo<ProjectDto>(_mapper.ConfigurationProvider).AsSingleQuery().ToListAsync(cancellationToken);
            if (projects.Count > 1) projects.Sort((p1, p2) => p1.Rating.CompareTo(p2.Rating));

            return Result<List<ProjectDto>>.Success(projects);
        }


    }
}
