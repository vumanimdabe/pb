using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace phonebook.data
{
    public class Database : IDatabase
    {
        private readonly IDbConnection _connection;
        public Database(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> ExecuteAsync(string sql, object param = null, CommandType command = CommandType.StoredProcedure)
        {
            return (await _connection.ExecuteAsync(sql, param, commandType: command) > 0);
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType command = CommandType.StoredProcedure)
        {
            return await _connection.QueryAsync<T>(sql, param, commandType: command);
        }
    }
}
