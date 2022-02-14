namespace Application.Experiences;

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
            var experience = await _context.Experiences.Include(p => p.Logo).Where(e => e.Id == request.Id).FirstOrDefaultAsync<Experience>();
            if (experience == null) return null;
            var photo = _photoAccessor.DeletePhoto(experience.Logo.Id);
            if (photo == null) return Result<Unit>.Failure("Failed to delete photo");

            _context.Remove(experience);
            _context.Remove(experience.Logo);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete");

            return Result<Unit>.Success(Unit.Value);
        }

    }
}
