using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Certificates
{
    public class List
    {
        public class Query : IRequest<Result<List<Certificate>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Certificate>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Certificate>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Certificate>>.Success(await _context.Certificates.ToListAsync(cancellationToken));
            }

        }

    }
}