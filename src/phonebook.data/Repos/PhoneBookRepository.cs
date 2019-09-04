using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using phonebook.data.Models;

namespace phonebook.data.Repos
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly IDatabase _database;

        public PhoneBookRepository(IDatabase db)
        {
            _database = db;
        }

        public async Task addEntryAsync(PhoneBookEntry entry)
        {
            await _database.ExecuteAsync($"insert into  `PhoneBookEntry` ( `Name`,  `PhoneNumber`) values( '{entry.Name}',  '{entry.PhoneNumber}')", command: System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<PhoneBookEntry>> GetEntriesByNameAsync(string name)
        {
            return await _database.QueryAsync<PhoneBookEntry>($"select * from `PhoneBookEntry` where `Name` like '%{name}%'", command: System.Data.CommandType.Text);
        }

        public async Task<IEnumerable<PhoneBookEntry>> GetEntriesByPhoneNumberAsync(string phoneNumber)
        {
            return await _database.QueryAsync<PhoneBookEntry>($"select * from `PhoneBookEntry` where `PhoneNumber` like '%{phoneNumber}%'", command: System.Data.CommandType.Text);
        }
    }
}
