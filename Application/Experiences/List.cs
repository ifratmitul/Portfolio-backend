namespace Application.Experiences;
public class List
{
    public class Query : IRequest<Result<List<ExperienceDto>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<ExperienceDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<ExperienceDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var exp = await _context.Experiences
                                    .ProjectTo<ExperienceDto>(_mapper.ConfigurationProvider)
                                    .OrderByDescending(e => e.StartDate)
                                    .ToListAsync(cancellationToken);
            
            return Result<List<ExperienceDto>>.Success(exp);
        }

    }

}
