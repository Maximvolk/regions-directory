using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

using RegionsDirectory.Core.Interfaces.Services;
using RegionsDirectory.Core.Interfaces.Repositories;
using RegionsDirectory.Core.Models;
using RegionsDirectory.Core.Responses;
using RegionsDirectory.Common;

namespace RegionsDirectory.Core.Services
{
    public class RegionsService : IRegionsService
    {
        private readonly IRegionsRepository _regionsRepository;
        private readonly ILogger _logger;

        public RegionsService(IRegionsRepository regionsRepository,
            ILogger<RegionsService> logger)
        {
            _regionsRepository = regionsRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Region>> GetRegionsAsync(
            string regionName, string regionShortName)
        {
            try
            {
                return await _regionsRepository.GetAsync(regionName, regionShortName);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Unexpected error occurred while extracting regions {regionName} {regionShortName}: {e.Message}",
                    e.InnerException?.Message);
                // Think on returning model with error message
                // It may be helpful in future for pagination
                return new Region[] {};
            }
        }
        
        public async Task<RegionResponse> AddRegionAsync(Region region)
        {
            try
            {
                var existingRegion = await _regionsRepository.GetAsync(region.Name, region.ShortName);

                if (existingRegion.Count() > 0)
                    return new RegionResponse("Such region already exists", CustomerCodes.RegionAlreadyExists);

                await _regionsRepository.AddAsync(region);
                // Think on extracting id of created region
                return new RegionResponse(region);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Unexpected error occurred while adding region {region.Name} {region.ShortName}: {e.Message}",
                    e.InnerException?.Message);
                return new RegionResponse("Unexpected error occurred", CustomerCodes.Unexpected);
            }
        }

        public async Task<RegionResponse> UpdateRegionAsync(int regionId, Region region)
        {
            var existingRegion = await _regionsRepository.FindByIdAsync(regionId);

            if (existingRegion == null)
            {
                _logger.LogWarning($"Attempt to update non-existent region (specified id: {regionId})");
                return new RegionResponse("Region not found", CustomerCodes.RegionNotFound);
            }
                
            try
            {
                await _regionsRepository.UpdateAsync(regionId, region);
                return new RegionResponse(region);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Unexpected error occurred while updating region #{regionId}: {e.Message}",
                    e.InnerException?.Message);
                return new RegionResponse("Unexpected error occurred", CustomerCodes.Unexpected);
            }
        }

        public async Task<RegionResponse> DeleteRegionAsync(int regionId)
        {
            var existingRegion = await _regionsRepository.FindByIdAsync(regionId);

            if (existingRegion == null)
            {
                _logger.LogWarning($"Attempt to delete non-existent region (specified id: {regionId})");
                return new RegionResponse("Region not found", CustomerCodes.RegionNotFound);
            }
                
            try
            {
                await _regionsRepository.DeleteAsync(regionId);
                return new RegionResponse(existingRegion);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Unexpected error occurred while deleting region #{regionId}: {e.Message}",
                    e.InnerException?.Message);
                return new RegionResponse("Unexpected error occurred", CustomerCodes.Unexpected);
            }
        }
    }
}