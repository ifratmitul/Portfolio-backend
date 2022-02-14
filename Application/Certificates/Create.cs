namespace Application.Certificates;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Certificate Certificate { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _dataContext;
        public Handler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            _dataContext.Certificates.Add(request.Certificate);
            var result = await _dataContext.SaveChangesAsync() > 0;
            if (!result) Result<Unit>.Failure("Failed to add certificate");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
