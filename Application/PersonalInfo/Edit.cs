using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interface;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.PersonalInfo
{
    public class Edit
    {
        public class Commnad : IRequest<Result<Unit>>
        {
            public MyProfile Profile { get; set; }

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
                if (request.Profile.Photofile == null)
                {
                    var profile = await _context.Profiles.FindAsync(request.Profile.Id);
                    if (profile == null) return null;
                    _mapper.Map(request.Profile, profile);

                }
                else
                {
                    var profile = await _context.Profiles.Include(p => p.Photo).Where(exp => exp.Id == request.Profile.Id).FirstOrDefaultAsync<MyProfile>();
                    if (profile == null) return null;
                    var removePhoto = await _photoAccessor.DeletePhoto(profile.Photo.Id);
                    if (removePhoto == null) return Result<Unit>.Failure("Failed to delete photo");
                    _context.Remove(profile.Photo);

                    var photoResult = await _photoAccessor.AddPhoto(request.Profile.Photofile);
                    if (photoResult == null) return Result<Unit>.Failure("Failed to upload photo");
                    var photo = new Photo
                    {
                        Id = photoResult.PublicId,
                        Url = photoResult.Url,
                        IsMain = true
                    };
                    request.Profile.Photo = photo;
                    _mapper.Map(request.Profile, profile);

                }



                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to Edit Data");

                return Result<Unit>.Success(Unit.Value);

            }
        }

    }
}