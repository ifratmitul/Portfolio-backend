using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Schools
{
    public class Edit
    {
        public class Commnad : IRequest
        {

            public Education Education { get; set; }

        }

        public class Handler : IRequestHandler<Commnad>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Commnad request, CancellationToken cancellationToken)
            {
                var data = await _context.Schools.FindAsync(request.Education.Id);

                _mapper.Map(request.Education, data);

                await _context.SaveChangesAsync();

                return Unit.Value;

            }
        }

    }
}