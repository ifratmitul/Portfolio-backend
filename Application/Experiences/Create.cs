namespace Application.Experiences;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Experience Experience { get; set; }
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
            if (request.Experience.PhotoFile == null) return Result<Unit>.Failure("Photo file missing");
            var photoResult = await _photoAccessor.AddPhoto(request.Experience.PhotoFile);

            if (photoResult == null) return Result<Unit>.Failure("Failed to Upload Photo");
            var photo = new Photo
            {
                Id = photoResult.PublicId,
                Url = photoResult.Url,
                IsMain = true
            };

            request.Experience.Logo = photo;
            _context.Experiences.Add(request.Experience);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to save data");



            return Result<Unit>.Success(Unit.Value);

        }
    }

}
