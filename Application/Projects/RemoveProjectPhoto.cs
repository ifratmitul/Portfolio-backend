namespace Application.Projects
{
    public class RemoveProjectPhoto
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string PhotoId { get; set; }
            public Guid ProjectId { get; set; }
        }

        public class ProjectPhotoRemover : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IPhotoAccessor _photoAccessor;
            private readonly DataContext _context;

            public ProjectPhotoRemover(DataContext context, IPhotoAccessor photoAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.ProjectId == Guid.Empty || request.PhotoId == null)
                    return Result<Unit>.Failure("PhotoId or  ProjectId not found");

                Project project = await _context.Projects
                                                .Where(proj => proj.Id == request.ProjectId)
                                                .Include(ph => ph.Photos)
                                                .FirstOrDefaultAsync();

                if (project == null) return null;
                Photo photoToRemove = project.Photos.Where(p => p.Id == request.PhotoId).FirstOrDefault();
                if (photoToRemove == null) return null;

                var result = await _photoAccessor.DeletePhoto(request.PhotoId);
                if (result == null) return Result<Unit>.Failure("Failed to delete photo from cloud");

                project.Photos = project.Photos.Where(p => p.Id != request.PhotoId).ToList();

                _context.Remove(photoToRemove);
                _context.Entry(project).State = EntityState.Modified;

                var res = await _context.SaveChangesAsync() > 0;
                if (res) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to save changes");
            }
        }
    }
}


