using Application.Skills;
namespace API.Controllers
{
    public class SkillController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetSkills()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromForm] Skill skill)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Skill = skill }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}