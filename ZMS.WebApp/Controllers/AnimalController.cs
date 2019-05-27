using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZMS.BLL.Abstracts;

namespace ZMS.WebApp.Controllers
{
    [Route("api/Animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut]
        public IActionResult Feed()
        {
            _service.Update(id, item);
            return Ok();
        }

    }
}
