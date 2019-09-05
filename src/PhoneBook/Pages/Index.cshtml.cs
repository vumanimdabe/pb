using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using phonebook.data.Models;
using phonebook.data.Repos;

namespace PhoneBook.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<PhoneBookEntry> PhoneBookEntries { get; set; }

        private readonly IPhoneBookRepository _repository;

        public IndexModel(IPhoneBookRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGet()
        {
            //http://localhost:63725/api/entries
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63725");

                var response = await client.GetAsync("api/entries");

                var x = await response.Content.ReadAsAsync<IEnumerable<PhoneBookEntry>>();

                PhoneBookEntries = x;
            }
        }
    }
}
