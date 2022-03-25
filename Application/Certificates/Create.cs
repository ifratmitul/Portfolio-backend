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
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(DataContext dataContext, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _dataContext = dataContext;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            if (request.Certificate.PhotoFile == null) return Result<Unit>.Failure("Fill missing");

            var res = await _photoAccessor.AddPhoto(request.Certificate.PhotoFile);
            if (res == null) return Result<Unit>.Failure("Failed to upload photo");


            var photo = new Photo
            {
                Id = res.PublicId,
                Url = res.Url,
                IsMain = true
            };
            request.Certificate.Logo = photo;

            _dataContext.Certificates.Add(request.Certificate);
            var result = await _dataContext.SaveChangesAsync() > 0;
            if (!result) Result<Unit>.Failure("Failed to add certificate");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
