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
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(DataContext context, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = await _context.Certificates.Include(c => c.Logo).Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (data == null) return null;

            if (data.Logo != null)
            {
                var res = await _photoAccessor.DeletePhoto(data.Logo.Id);
                if (res == null) return Result<Unit>.Failure("Failed to Delete Photo");
            }
            _context.Remove(data);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Delete Certificate");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
