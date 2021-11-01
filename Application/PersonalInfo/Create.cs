using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interface;
using Domain;
using MediatR;
using Persistence;

namespace Application.PersonalInfo
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MyProfile Profile { get; set; }
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
                if (request.Profile.Photofile == null) return Result<Unit>.Failure("File missing");
                var photoResult = await _photoAccessor.AddPhoto(request.Profile.Photofile);
                if (photoResult == null) return Result<Unit>.Failure("Failed to upload file");

                var photo = new Photo
                {
                    Id = photoResult.PublicId,
                    Url = photoResult.Url,
                    IsMain = true
                };

                request.Profile.Photo = photo;

                _context.Profiles.Add(request.Profile);
                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to add profile");


            }
        }
    }
}