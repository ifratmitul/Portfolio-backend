namespace Application.Schools;

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
            var education = await _context.Schools.Include(e => e.Logo).Where(e => e.Id == request.Id).FirstOrDefaultAsync();
            if (education == null) return null;

            if (education.Logo != null)
            {
                var res = await _photoAccessor.DeletePhoto(education.Logo.Id);
                if (res == null) return Result<Unit>.Failure("Failed to delete photo");
            }

            _context.Remove(education);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
