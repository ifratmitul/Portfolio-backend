using Application.Certificates;


namespace API.Controllers
{
    public class CertificateController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetCertificate()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddCertificate([FromForm] Certificate certificate)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Certificate = certificate }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCertificate(Guid id, [FromForm] Certificate certificate)
        {
            certificate.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Certificate = certificate }));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}