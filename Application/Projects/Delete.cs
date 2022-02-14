namespace Application.Projects;

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
        private readonly IMapper _mapper;
        public Handler(DataContext context, IPhotoAccessor photoAccessor, IMapper mapper)
        {
            _mapper = mapper;
            _photoAccessor = photoAccessor;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {


            var project = await _context.Projects.Include(p => p.Photos).Where(p => p.Id == request.Id).FirstOrDefaultAsync();

            if (project == null) return null;
            if (project.Photos.Count > 0)
            {
                foreach (Photo photo in project.Photos)
                {
                    var photoResult = await _photoAccessor.DeletePhoto(photo.Id);
                    if (photoResult == null) return Result<Unit>.Failure("Failed to delete photo");
                    _context.Remove(photo);

                }
            }

            _context.Remove(project);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete");

            return Result<Unit>.Success(Unit.Value);
        }

    }

}
