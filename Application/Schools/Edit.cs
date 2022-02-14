namespace Application.Schools;
public class Edit
{
    public class Commnad : IRequest<Result<Unit>>
    {

        public Education Education { get; set; }

    }

    public class Handler : IRequestHandler<Commnad, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Commnad request, CancellationToken cancellationToken)
        {
            var data = await _context.Schools.FindAsync(request.Education.Id);
            if (data == null) return null;

            _mapper.Map(request.Education, data);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Edit Data");

            return Result<Unit>.Success(Unit.Value);

        }
    }

}
