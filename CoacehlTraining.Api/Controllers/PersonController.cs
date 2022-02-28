using CoacehlTraining.Core.DTO;
using CoacehlTraining.Core.Interfaces;
using GV.DomainModel.SharedKernel.Interop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoacehlTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ApiBaseController
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<PersonInfo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<IEnumerable<PersonInfo>>>> GetPersons()
        {
            return await personService.GetAll();
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<Result<PersonResponse>>> AddPerson([FromBody] PersonInfo personInfo)
        {
            return await personService.Add(personInfo);
        }
    }
}
