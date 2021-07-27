using System.Threading.Tasks;
using RegionsDirectory.Core.Models;

namespace RegionsDirectory.Core.Interfaces.Repositories
{
    public interface IRegionsRepository
    {
        Task<Region> FindByIdAsync(int id);
        Task<Region[]> GetAsync(string regionName, string regionShortName);
        Task AddAsync(Region region);
        Task UpdateAsync(int regionId, Region region);
        Task DeleteAsync(int regionId);
    }
}