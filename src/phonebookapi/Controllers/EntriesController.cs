using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phonebook.data.Models;
using phonebook.data.Repos;

namespace phonebookapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IPhoneBookRepository _repository;

        public EntriesController(IPhoneBookRepository repo)
        {
            _repository = repo;
        }

        // GET api/entries
        [HttpGet]
        public async Task<IEnumerable<PhoneBookEntry>> Get()
        {
            return await _repository.GetEntriesByNameAsync(string.Empty);
        }

        // Get api/entries/Jon
        [HttpGet("{name}")]
        public async Task<IEnumerable<PhoneBookEntry>> GetByName([FromQuery]string name)
        {
            return await _repository.GetEntriesByNameAsync(name);
        }

        // Get api/entries/Jon
        [HttpGet("phone/{phoneNumber}")]
        public async Task<IEnumerable<PhoneBookEntry>> GetByPhoneNumber(string phoneNumber)
        {
            return await _repository.GetEntriesByPhoneNumberAsync(phoneNumber);
        }

        // Post api/entries
        [HttpPost]
        public async Task Create([FromBody] PhoneBookEntry entry)
        {
            await _repository.addEntryAsync(entry);
        }
    }
}