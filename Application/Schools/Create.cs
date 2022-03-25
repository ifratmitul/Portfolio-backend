using FluentValidation;

namespace Application.Schools;
public class Create
{
    public class Command : IRequest<Result<Unit>>
    {

        public Education Education { get; set; }

    }

    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Education).SetValidator(new EducationValidator());
        }
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

            var photoRes = await _photoAccessor.AddPhoto(request.Education.PhotoFile);
            if (photoRes == null) return Result<Unit>.Failure("Failed to upload photo");

            var photo = new Photo
            {
                Id = photoRes.PublicId,
                Url = photoRes.Url,
                IsMain = true
            };

            request.Education.Logo = photo;
            _context.Schools.Add(request.Education);

            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Failure("Failed to Create School");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
