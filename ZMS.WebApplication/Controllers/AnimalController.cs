using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ZMS.BLL.Abstracts;
using ZMS.Models;
using ZMS.WebApplication.Infrastructure.Filters;

namespace ZMS.WebApplication.Controllers
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
        public ActionResult<Animal> Get(int id)
        {
            if (id < 1)
                return BadRequest("Id is not valid");

            return Ok(_service.Get(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{animalSex}/{isHungry}")]
        public ActionResult<IEnumerable<Animal>> FilterBySexAndHungry(Sex animalSex, bool isHungry)
        {
            return Ok(_service.Filter(a => a.Sex == animalSex && a.IsHungry == isHungry));
        }

        [HttpPost]
        [ExceptionFilter]
        public ActionResult AddNewAnimal([FromBody] Animal animal)
        {
            if (!animal.IsValid())
                return BadRequest("Data is not valid");

            _service.AddNew(animal);
            return Ok();
        }

        [HttpPut("{id}")]
        [ExceptionFilter]
        public ActionResult Feed(int id)
        {
            if (id < 1)
                return BadRequest("Id is not valid");

            _service.Feed(id);
            return Ok();
        }

        [HttpPut]
        [ExceptionFilter]
        public ActionResult FeedAllAnimals()
        {
            _service.FeedAll();
            return Ok();
        }

        [HttpPut("{animalId}/{caretakerId}")]
        [ExceptionFilter]
        public ActionResult AttachCaretaker(int animalId, int caretakerId)
        {
            if (animalId < 1 || caretakerId < 1)
                return BadRequest("Id is not valid");

            _service.AttachCaretaker(animalId, caretakerId);
            return Ok();
        }
    }
}