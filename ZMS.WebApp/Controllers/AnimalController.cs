using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZMS.BLL.Abstracts;
using ZMS.BLL.DTO;
using ZMS.BLL.Infrastructure;

namespace ZMS.WebApp.Controllers
{
    [Route("api/Animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalDTO> Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (NullDataException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnimalDTO>> Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (NullDataException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AddNewAnimal([FromBody] AnimalDTO animal)
        {
            try
            {
                _service.AddNew(animal);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Feed(int id, [FromBody] string food)
        {
            try
            {
                _service.Feed(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullDataException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public ActionResult AttachCaretaker(int animalId, int caretakerId)
        {
            try
            {
                _service.AttachCaretaker(animalId, caretakerId);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullDataException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}