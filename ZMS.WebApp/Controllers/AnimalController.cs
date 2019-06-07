using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZMS.BLL.Abstracts;
using ZMS.BLL.DTO;
using ZMS.WebApp.Infrastructure.Filters;
using ZMS.WebApp.Infrastructure;

namespace ZMS.WebApp.Controllers
{
    [Route("api/Animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ExceptionFilter]
        public ActionResult<AnimalDTO> Get(int id)
        {
            if(id < 1)
                return BadRequest("Id is not valid");

            return Ok(_service.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalDTO>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        [ExceptionFilter]
        public ActionResult AddNewAnimal([FromBody] AnimalDTO animal)
        {
            if(!new ValidationData().IsValidate(animal))
                return BadRequest("Data is not valid");

            _service.AddNew(animal);
            return Ok();
        }

        [HttpPut("{id}")]
        [ExceptionFilter]
        public ActionResult Feed(int id)
        {
            if(id < 1)
                return BadRequest("Id is not valid");

            _service.Feed(id);
            return Ok();
        }

        [HttpPut("{animalId}/{caretakerId}")]
        [ExceptionFilter]
        public ActionResult AttachCaretaker(int animalId, int caretakerId)
        {
            if(animalId < 1 || caretakerId < 1)
                return BadRequest("Id is not valid");

            _service.AttachCaretaker(animalId, caretakerId);
            return Ok();
        }
    }
}