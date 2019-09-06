using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using phonebook.data;
using phonebook.data.Models;
using phonebook.data.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests.Repos
{
    [TestFixture]
    public class PhoneBookRepositoryTests
    {
        private  IDatabase _database;

        private IPhoneBookRepository repo;

        private PhoneBookEntry payload;

        [SetUp]
        public async Task Setup()
        {
            _database = Substitute.For<IDatabase>();

            repo = new PhoneBookRepository(_database);

            var payload = new PhoneBookEntry {
                Name  = "Jon Doe",
                PhoneNumber = "+2710 555 12 12"
            };
        }

        [Test]
        public async Task AsddEntryAsync_Given_ValidInput_Should_AddToDatabase()
        {
            _database = Substitute.For<IDatabase>();

            repo = new PhoneBookRepository(_database);

            var payload = new PhoneBookEntry
            {
                Name = "Jon Doe",
                PhoneNumber = "+2710 555 12 12"
            };

            repo = new PhoneBookRepository(_database);

            await repo.addEntryAsync(payload);

            await _database.Received().ExecuteAsync(Arg.Any<string>(), command: System.Data.CommandType.Text);
        }

        [Test]
        public async Task GetEntriesByNameAsync_Given_ValidInput_Should_GetList()
        {
            _database = Substitute.For<IDatabase>();

            repo = new PhoneBookRepository(_database);

            var payload = new PhoneBookEntry
            {
                Name = "Jon Doe",
                PhoneNumber = "+2710 555 12 12"
            };

            repo = new PhoneBookRepository(_database);

            var response = await repo.GetEntriesByNameAsync(payload.Name);

            await _database.Received().QueryAsync<PhoneBookEntry>(Arg.Any<string>(), command: System.Data.CommandType.Text);
        }
    }
}
