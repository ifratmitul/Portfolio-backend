
namespace Application.PersonalInfo;

public class Details
{
    public class Query : IRequest<Result<ProfileDto>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<ProfileDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ProfileDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var myProfile = await _context.Profiles.ProjectTo<ProfileDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

            return Result<ProfileDto>.Success(myProfile);
        }

    }

}
