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
        private readonly IPhotoAccessor _photoAccessor;
        public Handler(DataContext context, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _photoAccessor = photoAccessor;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Commnad request, CancellationToken cancellationToken)
        {
            var data = await _context.Schools.Include(e => e.Logo).Where(e => e.Id == request.Education.Id).FirstOrDefaultAsync();
            if (data == null) return null;
            Console.WriteLine(JsonSerializer.Serialize(data));

            if (request.Education.PhotoFile != null)
            {
                if (data.Logo != null)
                {
                    var res = await _photoAccessor.DeletePhoto(data.Logo.Id);
                    if (res == null) return Result<Unit>.Failure("Failed to delete photo");
                }


                var newPhoto = await _photoAccessor.AddPhoto(request.Education.PhotoFile);
                if (newPhoto == null) return Result<Unit>.Failure("Failed to upload new photo");

                var photo = new Photo
                {
                    IsMain = true,
                    Id = newPhoto.PublicId,
                    Url = newPhoto.Url
                };
                request.Education.Logo = photo;
            }

            _mapper.Map(request.Education, data);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Edit Data");

            return Result<Unit>.Success(Unit.Value);

        }
    }

}
