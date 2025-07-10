using Microsoft.AspNetCore.Mvc;
using Person_Api.Repositories;

namespace Person_Api.Controllers
{
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        private static List<Person> persons = new List<Person>
        {
            new Person
            {
                Id = 1,
                Email = "john.doe@example.com",
                Profile = new Company
                {
                    Name = "John Doe"
                }
            },
            new Person
            {
                Id = 2,
                Email = "jane.smith@example.com",
                Profile = new Company
                {
                    Name = "Jane Smith"
                }
            },
            new Person
            {
                Id = 3,
                Email = "michael.brown@example.com",
                Profile = new Company
                {
                    Name = "Michael Brown"
                }
            },
            new Person
            {
                Id = 4,
                Email = "lucy.wilson@example.com",
                Profile = new Company
                {
                    Name = "Lucy Wilson"
                }
            },
            new Person
            {
                Id = 5,
                Email = "david.johnson@example.com",
                Profile = new Company
                {
                    Name = "David Johnson"
                }
            }
        };

        [HttpGet("GetPersons")]
        public ActionResult<IEnumerable<Person>> GetPersons(int page = 1, int pageSize = 2)
        {
            return Ok(_personRepository.GetPersons());
        }
        
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            var person = persons.Find(p => p.Id == id);

            if (person == null)
            {
                return NotFound(); 
            }
            return Ok(_personRepository.GetPersons());
        }
    }
    
}