using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using RegionsDirectory.Core.Interfaces.Repositories;
using RegionsDirectory.Core.Models;
using RegionsDirectory.Persistence.Infrastructure;

namespace RegionsDirectory.Persistence.Repositories
{
    public class RegionsRepository : IRegionsRepository
    {
        private readonly IDbWrapper _db;

        public RegionsRepository(IDbWrapper db)
        {
            _db = db;
        }

        public async Task<Region> FindByIdAsync(int id)
        => await _db.QueryFirstAsync<Region>($"SELECT * FROM Regions WHERE Id = {id}");

        public async Task<IEnumerable<Region>> GetAsync(string regionName, string regionShortName)
        {
            var param = new { RegionName = regionName, RegionShortName= regionShortName};
            var sql = new StringBuilder("SELECT * FROM Regions WHERE 1 = 1 ");

            if (!string.IsNullOrEmpty(regionName))
                sql.Append("AND Name = :RegionName ");

            if (!string.IsNullOrEmpty(regionShortName))
                sql.Append("AND ShortName = :RegionShortName");

            return await _db.QueryAsync<Region>(sql.ToString(), param);
        }

        public async Task AddAsync(Region region)
        {
            var param = new { RegionName = region.Name, RegionShortName= region.ShortName};
            var sql = "INSERT INTO Regions (Name, ShortName) VALUES (:RegionName, :RegionShortName)";

            await _db.ExecuteAsync(sql, param);
        }

        public async Task UpdateAsync(int regionId, Region region)
        {
            var param = new { RegionName = region.Name, RegionShortName= region.ShortName};
            var sql = new StringBuilder("UPDATE Regions SET ");

            if (!string.IsNullOrEmpty(region.Name))
                sql.Append("Name = :RegionName, ");

            if (!string.IsNullOrEmpty(region.ShortName))
                sql.Append("ShortName = :RegionShortName, ");

            sql.Append($"Id = Id WHERE Id = {regionId}");

            await _db.QueryAsync<Region>(sql.ToString(), param);
        }
        
        public async Task DeleteAsync(int regionId)
        {
            var sql = $"DELETE FROM Regions WHERE Id = {regionId}";
            await _db.ExecuteAsync(sql);
        }
    }
}