using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

using Oracle.ManagedDataAccess.Client;
using Dapper;

namespace RegionsDirectory.Persistence.Infrastructure
{
    public class DbWrapper : IDbWrapper
    {
        private readonly DbOptions _options;
        private readonly ILogger _logger;

        public DbWrapper(IOptions<DbOptions> options, ILogger<DbWrapper> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null)
        {
            using (var conn = new OracleConnection(_options.ConnectionString))
            {
                _logger.LogInformation($"Executing DB query {query} with following params: {param}");
                var results = await conn.QueryAsync<T>(query, param);

                return results;
            }
        }

        public async Task<T> QueryFirstAsync<T>(string query)
        {
            using (var conn = new OracleConnection(_options.ConnectionString))
            {
                _logger.LogInformation($"Executing DB query {query}");
                var results = await conn.QueryFirstOrDefaultAsync<T>(query);

                return results;
            }
        }

        public async Task ExecuteAsync(string query, object param = null)
        {
            using (var conn = new OracleConnection(_options.ConnectionString))
            {
                _logger.LogInformation($"Executing DB query {query} with following params: {param}");
                var results = await conn.ExecuteAsync(query, param);
            }
        }
    }
}