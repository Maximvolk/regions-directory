using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegionsDirectory.Persistence.Infrastructure
{
    public interface IDbWrapper
    {
         Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null);
         Task<T> QueryFirstAsync<T>(string query);
         Task ExecuteAsync(string query, object param = null);
    }
}