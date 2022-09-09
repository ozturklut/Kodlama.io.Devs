using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnology;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProgrammingTechnologyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
        {
            CreateProgrammingTechnologyDto createProgrammingTechnologyDto = await Mediator.Send(createProgrammingTechnologyCommand);

            return Created("", createProgrammingTechnologyDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };

            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
        {
            DeletedProgrammingTechnologyDto deletedProgrammingTechnologyDto = await Mediator.Send(deleteProgrammingTechnologyCommand);
            return Ok(deletedProgrammingTechnologyDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
        {
            UpdatedProgrammingTechnologyDto updatedProgrammingTechnologyDto = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Ok(updatedProgrammingTechnologyDto);
        }
    }
}

