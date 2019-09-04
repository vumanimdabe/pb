using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace phonebook.data
{
    public interface IDatabase
    {
        Task<bool> ExecuteAsync(string sql, object param = null, CommandType command = CommandType.StoredProcedure);

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType command = CommandType.StoredProcedure);
    }
}
