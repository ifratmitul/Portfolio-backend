// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using Application.Core;
// using AutoMapper;
// using Domain;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// namespace Application.Projects
// {
//     public class List
//     {
//         public class Query : IRequest<Result<List<Project>>>
//         {

//         }

//         public class Handler : IRequestHandler<Query, Result<List<Project>>>
//         {
//             private readonly DataContext _context;
//             private readonly IMapper _mapper;
//             public Handler(DataContext context, IMapper mapper)
//             {
//                 _mapper = mapper;
//                 _context = context;
//             }

//             public async Task<Result<List<Project>>> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 // var skills = await _context.Skills.ProjectTo<SkillDto>(_mapper.ConfigurationProvider)
//                 // .ToListAsync(cancellationToken);

//                 var projects = await _context.Projects.ToListAsync(cancellationToken);

//                 return Result<List<Project>>.Success(projects);
//             }


//         }
//     }
// }