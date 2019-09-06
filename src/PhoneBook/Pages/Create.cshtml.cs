using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using phonebook.data.Models;

namespace PhoneBook.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public async Task OnGet()
        {

        }

        public async Task OnPost()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63725");

                var payload = new PhoneBookEntry
                {
                    Name = Name,
                    PhoneNumber = PhoneNumber[0] == '+' ? PhoneNumber : $"+27{PhoneNumber}"
                };

                var response = await client.PostAsJsonAsync<PhoneBookEntry>("api/entries", payload);

                Message = response.IsSuccessStatusCode ? "New Record Created." : "An error occured when Creating your record.";
            }
        }
    }
}