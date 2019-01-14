using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services.Implementations;

namespace RestWithASPNET.Controllers
{
    /*Mapeia as requisições de http://localhost:{porta}/api/person
     Por padrão o ASP .NET Core mapeia todas as classes que extendem Controller
     pegando a primeira parte do nome da classe em lower case [PersonS]Controller
     e expõe como endpoint REST*/
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]     
    public class PersonsController : Controller
    {
        //Declaração do serviço usado
        private IPersonService _personService;

        /*Injeção de uma instância de IpersonService ao criar uma instancia de PersonController.*/
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           _personService.Delete(id);
            return NoContent();
        }

    }
}
