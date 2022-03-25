namespace Application.Certificates;

public class Edit

{
    public class Command : IRequest<Result<Unit>>
    {
        public Certificate Certificate { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var data = await _context.Certificates.Include(c => c.Logo).Where(c => c.Id == request.Certificate.Id).FirstOrDefaultAsync();
            if (data == null) return null;

            if (request.Certificate.PhotoFile != null)
            {
                if (data.Logo != null)
                {
                    var res = await _photoAccessor.DeletePhoto(data.Logo.Id);
                    if (res == null) return Result<Unit>.Failure("Failed to delete photo");
                }


                var newPhoto = await _photoAccessor.AddPhoto(request.Certificate.PhotoFile);
                if (newPhoto == null) return Result<Unit>.Failure("Failed to upload new photo");

                var photo = new Photo
                {
                    IsMain = true,
                    Id = newPhoto.PublicId,
                    Url = newPhoto.Url
                };
                request.Certificate.Logo = photo;
            }


            _mapper.Map(request.Certificate, data);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to update certificate");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
