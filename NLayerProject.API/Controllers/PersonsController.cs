using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _service;

        public PersonsController(IService<Person> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var persons = await _service.GetAllAsync();
            return Ok(persons);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person) 
        {
            var addPerson = await _service.AddAsync(person);
            return Ok(addPerson);
        }
    }
}
