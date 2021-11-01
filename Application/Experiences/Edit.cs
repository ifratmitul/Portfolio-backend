using System;
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

namespace Application.Experiences
{
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

                if (request.Experience.PhotoFile == null)
                {
                    var experience = await _context.Experiences.FindAsync(request.Experience.Id);
                    if (experience == null) return null;
                    _mapper.Map(request.Experience, experience);

                }
                else
                {
                    var experience = await _context.Experiences.Include(p => p.Logo).Where(exp => exp.Id == request.Experience.Id).FirstOrDefaultAsync<Experience>();
                    if (experience == null) return null;
                    var removePhoto = await _photoAccessor.DeletePhoto(experience.Logo.Id);
                    if (removePhoto == null) return Result<Unit>.Failure("Failed to delete photo");
                    _context.Remove(experience.Logo);

                    var photoResult = await _photoAccessor.AddPhoto(request.Experience.PhotoFile);
                    if (photoResult == null) return Result<Unit>.Failure("Failed to upload photo");
                    var photo = new Photo
                    {
                        Id = photoResult.PublicId,
                        Url = photoResult.Url,
                        IsMain = true
                    };
                    request.Experience.Logo = photo;
                    _mapper.Map(request.Experience, experience);

                }


                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to Edit Data");

                return Result<Unit>.Success(Unit.Value);

            }
        }

    }
}