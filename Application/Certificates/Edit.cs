using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Certificates
{
    public class Edit

    {
        public class Command : IRequest<Result<Unit>>
        {
            public Certificate Certificate { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = await _context.Certificates.FindAsync(request.Certificate.Id);
                if (data == null) return null;
                _mapper.Map(request.Certificate, data);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update certificate");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}