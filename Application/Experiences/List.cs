using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Experiences
{
    public class List
    {
        public class Query : IRequest<Result<List<ExperienceDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<ExperienceDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ExperienceDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var skills = await _context.Experiences.ProjectTo<ExperienceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

                return Result<List<ExperienceDto>>.Success(skills);
            }

        }

    }
}