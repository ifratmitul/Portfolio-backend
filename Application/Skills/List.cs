using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Skills
{
    public class List
    {
        public class Query : IRequest<Result<List<SkillDto>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<SkillDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<SkillDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var skills = await _context.Skills.ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
                if (skills.Count > 1) skills.Sort((s1, s2) => s1.Rating.CompareTo(s2.Rating));
                return Result<List<SkillDto>>.Success(skills);
            }

        }
    }
}