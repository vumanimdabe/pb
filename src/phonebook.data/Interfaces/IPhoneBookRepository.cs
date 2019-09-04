using phonebook.data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace phonebook.data.Repos
{
    public interface IPhoneBookRepository
    {
        Task<IEnumerable<PhoneBookEntry>> GetEntriesByNameAsync(string name);
        Task<IEnumerable<PhoneBookEntry>> GetEntriesByPhoneNumberAsync(string phoneNumber);
        Task addEntryAsync(PhoneBookEntry entry);
    }
}
