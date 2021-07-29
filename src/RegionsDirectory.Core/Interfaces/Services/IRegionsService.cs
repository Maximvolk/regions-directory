using System.Threading.Tasks;
using System.Collections.Generic;
using RegionsDirectory.Core.Models;
using RegionsDirectory.Core.Responses;

namespace RegionsDirectory.Core.Interfaces.Services
{
    public interface IRegionsService
    {
        Task<IEnumerable<Region>> GetRegionsAsync(string regionName, string regionShortName);
        Task<RegionResponse> AddRegionAsync(Region region);
        Task<RegionResponse> UpdateRegionAsync(int regionId, Region region);
        Task<RegionResponse> DeleteRegionAsync(int regionId);
    }
}