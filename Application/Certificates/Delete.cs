namespace Application.Certificates;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }

    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = await _context.Certificates.FindAsync(request.Id);
            if (data == null) return null;
            _context.Remove(data);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Delete Certificate");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
