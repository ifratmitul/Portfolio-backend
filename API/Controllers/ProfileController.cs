using Application.PersonalInfo;

namespace API.Controllers
{
    public class ProfileController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetProfileDetails()
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