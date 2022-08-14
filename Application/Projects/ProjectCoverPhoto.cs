namespace Application.Projects
{
    public class ProjectCoverPhoto
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ProjectId { get; set; }
            public string PhotoId { get; set; }
        }

        public class ProjectCoverPhotoChangeHandler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public ProjectCoverPhotoChangeHandler(DataContext context)
            {
                _context = context;

            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.ProjectId == Guid.Empty)
                    return Result<Unit>.Failure("Project Id or Photo Id not found, Must include both Project and PhotoID");

                Project project = await _context.Projects
                                                .Where(p => p.Id == request.ProjectId)
                                                .Include(p => p.Photos).FirstOrDefaultAsync();

                if (project == null) return null;
                if (project.Photos.Where(p => p.Id == request.PhotoId).FirstOrDefault() == null) return null;

                foreach (Photo item in project.Photos)
                {
                    if (item.Id == request.PhotoId)
                    {
                        item.IsMain = true;

                    }
                    else
                    {
                        item.IsMain = false;
                    }

                }

                _context.Entry(project).State = EntityState.Modified;


                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to save changes");

            }
        }
    }
}
