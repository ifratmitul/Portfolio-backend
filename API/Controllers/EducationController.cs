using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Schools;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EducationController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetDegrees()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> AddDegrees(Education education)
        {

            return HandleResult(await Mediator.Send(new Create.Command { Education = education }));

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditDegree(Guid id, Education education)
        {
            education.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Commnad { Education = education }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }


    }
}