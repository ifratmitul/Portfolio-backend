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
            var school = await _context.Schools.ProjectTo<EducationDto>(_mapper.ConfigurationProvider)
                                                                       .OrderBy( s => s.Priority)
                                                                       .ToListAsync(cancellationToken);
           
            return Result<List<EducationDto>>.Success(school);
        }
    }
}
