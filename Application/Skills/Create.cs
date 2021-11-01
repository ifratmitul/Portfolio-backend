using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interface;
using Application.Photos;
using Domain;
using MediatR;
using Persistence;

namespace Application.Skills
{
    public class Create
    {

        public class Command : IRequest<Result<Unit>>
        {
            public Skill Skill { get; set; }

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
                Console.WriteLine(request.Skill.SkillName);
                if (request.Skill.PhotoFile == null) return Result<Unit>.Failure("File Missing");
                var photoResult = await _photoAccessor.AddPhoto(request.Skill.PhotoFile);

                if (photoResult == null) return Result<Unit>.Failure("Failed to Upload Photo");
                var photo = new Photo
                {
                    Id = photoResult.PublicId,
                    Url = photoResult.Url,
                    IsMain = true
                };

                request.Skill.Photo = photo;
                _context.Skills.Add(request.Skill);

                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Failure("Failed to add skill");

            }
        }

    }
}