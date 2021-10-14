using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class EducationController : BaseApiController
    {
        private readonly DataContext _context;
        public EducationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Education>>> GetDegrees()
        {

            var data = await _context.Schools.ToListAsync();

            return data;

        }


    }
}