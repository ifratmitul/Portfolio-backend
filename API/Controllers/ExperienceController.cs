using Application.Experiences;

namespace API.Controllers
{
    public class ExperienceController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllExperience()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience([FromForm] Experience exp)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Experience = exp }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditExperience(Guid id, [FromForm] Experience exp)
        {
            exp.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Commnad { Experience = exp }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}