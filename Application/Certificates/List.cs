namespace Application.Certificates;

public class List
{
    public class Query : IRequest<Result<List<CertificateDto>>>
    {

    }

    public class Handler : IRequestHandler<Query, Result<List<CertificateDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<CertificateDto>>> Handle(Query request, CancellationToken cancellationToken)
        {

            var certificates = await _context.Certificates.ProjectTo<CertificateDto>(_mapper.ConfigurationProvider)
                                                           .OrderBy(c => c.Priority)
                                                           .ToListAsync(cancellationToken);

            return Result<List<CertificateDto>>.Success(certificates);
        }

    }

}
