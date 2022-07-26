namespace Application.Experiences;

public class Edit
{
    public class Commnad : IRequest<Result<Unit>>
    {
        public Experience Experience { get; set; }

    }

    public class Handler : IRequestHandler<Commnad, Result<Unit>>
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

        public async Task<Result<Unit>> Handle(Commnad request, CancellationToken cancellationToken)
        {
            var experience = await _context.Experiences
                                            .Where(e => e.Id == request.Experience.Id)
                                            .Include(e => e.Logo).FirstOrDefaultAsync();

            if (experience == null) return null;
            if (request.Experience.PhotoFile != null)
            {
                var removePhoto = await _photoAccessor.DeletePhoto(experience.Logo.Id);
                if (removePhoto == null) return Result<Unit>.Failure("Failed to delete photo");
                _context.Photos.Remove(experience.Logo);

                var photoResult = await _photoAccessor.AddPhoto(request.Experience.PhotoFile);
                if (photoResult == null) return Result<Unit>.Failure("Failed to upload photo");
                var photo = new Photo
                {
                    Id = photoResult.PublicId,
                    Url = photoResult.Url,
                    IsMain = true
                };
                request.Experience.Logo = photo;
            }
            else
            {
                request.Experience.Logo = experience.Logo;
            }

            _mapper.Map(request.Experience, experience);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Edit Data");

            return Result<Unit>.Success(Unit.Value);

        }
    }

}
