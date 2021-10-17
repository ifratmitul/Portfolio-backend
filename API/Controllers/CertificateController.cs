using System;
using System.Threading.Tasks;
using Application.Certificates;
using Domain;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddCertificate(Certificate certificate)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Certificate = certificate }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCertificate(Guid id, Certificate certificate)
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