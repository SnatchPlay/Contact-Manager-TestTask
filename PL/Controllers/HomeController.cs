using AutoMapper;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;
using System.Text.Json.Serialization;

namespace PL.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly ICSVProcessing _csvService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, IPersonService personService, IMapper mapper, ICSVProcessing csvService)
        {
            _personService = personService;
            _csvService = csvService;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult <IEnumerable<PersonDTO>> GetAll()
        
        {
            return Ok(_personService.GetAll());
        }
        [HttpGet("{id}")]
        public PersonDTO GetById(int id)
        {
            return _personService.GetById(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public PersonViewModel Create(int id, string name, DateOnly dateOfBirth, bool isMarried, string phoneNumber, decimal salary)
        {
            var person= new PersonViewModel { Id = id, Name = name, DateOfBirth = dateOfBirth, IsMarried = isMarried, PhoneNumber = phoneNumber, Salary = salary };
            var personDTO = _mapper.Map<PersonDTO>(person);
            return _mapper.Map<PersonViewModel>(_personService.Add(personDTO));
        }
        [HttpPost("read-csv")]
        public ActionResult GetEmployeeCSV([FromForm] IFormFileCollection file)
        {
            var employees = _csvService.ParseCSV(file[0].OpenReadStream());
            foreach (var employee in employees)
            {
                _personService.Add(employee);
            }
            return Ok(employees);
        }
        [HttpPut("{id}")]
        public PersonViewModel Update(int id, string name, DateOnly dateOfBirth, bool isMarried, string phoneNumber, decimal salary)
        
        {
            var person = new PersonViewModel { Id = id, Name = name, DateOfBirth = dateOfBirth, IsMarried = isMarried, PhoneNumber = phoneNumber, Salary = salary };
            var personDTO = _mapper.Map<PersonDTO>(person);
            return _mapper.Map<PersonViewModel>(_personService.Update(personDTO));
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok();
        }
    }
}
