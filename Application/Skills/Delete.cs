using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
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
            public Handler(DataContext context, IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var skill = await _context.Skills.Include(p => p.Photo).Where(skill => skill.Id == request.Id).FirstOrDefaultAsync<Skill>();
                if (skill == null) return null;
                var photo = _photoAccessor.DeletePhoto(skill.Photo.Id);
                if (photo == null) return Result<Unit>.Failure("Failed to delete photo");

                _context.Remove(skill);
                _context.Remove(skill.Photo);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete");

                return Result<Unit>.Success(Unit.Value);
            }

        }
    }
}