using System;
using System.Threading.Tasks;
using Application.PersonalInfo;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfileController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllExperience()
        {
            return HandleResult(await Mediator.Send(new Details.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddProfileDetails([FromForm] MyProfile p)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Profile = p }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditExperience(Guid id, [FromForm] MyProfile p)
        {
            p.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Commnad { Profile = p }));
        }

    }
}