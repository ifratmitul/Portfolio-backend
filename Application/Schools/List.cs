namespace Application.Schools;
public class List
{
    public class Query : IRequest<Result<List<EducationDto>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<EducationDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<EducationDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools.ProjectTo<EducationDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            if (school.Count > 1) school.Sort((s1, s2) => s1.Priority.CompareTo(s2.Priority));
            return Result<List<EducationDto>>.Success(school);
        }
    }
}
