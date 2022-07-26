using Application.Projects;
namespace API.Controllers
{
    public class ProjectController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromForm] Project project)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Project = project }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProject(Guid id, [FromForm] Project project)
        {
            project.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Project = project }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectDetails(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPut("{projectId}/photo/{photoId}")]
        public async Task<IActionResult> ChooseProjectCoverPhoto(Guid projectId, string photoId)
        {
            return HandleResult(await Mediator.Send(new ProjectCoverPhoto.Command { PhotoId = photoId, ProjectId = projectId }));
        }

        [HttpPut("delete/photo/{photoId}/project/{projectId}")]
        public async Task<IActionResult> RemoveProjectPhoto (string photoId, Guid projectId)
        {
            return HandleResult(await Mediator.Send(new RemoveProjectPhoto.Command
            {
                PhotoId = photoId,
                ProjectId = projectId
            }));
        }



    }
}