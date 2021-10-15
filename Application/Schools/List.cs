using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class List
    {
        public class Query : IRequest<Result<List<Education>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Education>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Education>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Education>>.Success(await _context.Schools.ToListAsync(cancellationToken));
            }
        }
    }
}