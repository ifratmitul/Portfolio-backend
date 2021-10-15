using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Schools
{
    public class List
    {
        public class Query : IRequest<List<Education>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Education>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Education>> Handle(Query request, CancellationToken cancellationToken)
            {
                var data = await _context.Schools.ToListAsync();
                //Console.WriteLine(data);

                return data;
            }
        }
    }
}