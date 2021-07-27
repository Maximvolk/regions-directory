using System.Threading.Tasks;
using RegionsDirectory.Core.Models;
using RegionsDirectory.Core.Responses;

namespace RegionsDirectory.Core.Interfaces.Services
{
    public interface IRegionsService
    {
        Task<Region[]> GetRegionsAsync(string regionName, string regionShortName);
        Task<RegionResponse> AddRegionAsync(Region region);
        Task<RegionResponse> UpdateRegionAsync(int regionId, Region region);
        Task<RegionResponse> DeleteRegionAsync(int regionId);
    }
}