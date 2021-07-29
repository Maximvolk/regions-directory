using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RegionsDirectory.Core.Interfaces.Services;
using RegionsDirectory.Core.Responses;
using RegionsDirectory.Core.Models;
using RegionsDirectory.Common.Resources;
using RegionsDirectory.Common;
using AutoMapper;

namespace RegionsDirectory.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IRegionsService _regionsService;

        public RegionsController(IMapper mapper,
            ILogger<RegionsController> logger, IRegionsService regionsService)
        {
            _mapper = mapper;
            _logger = logger;
            _regionsService = regionsService;
        }

        [HttpGet]
        public async Task<IEnumerable<RegionResource>> GetRegionsAsync(
            [FromQuery]string regionName, [FromQuery]string regionShortName)
        {
            _logger.LogInformation($"Extracting regions (name = {regionName}, shortName = {regionShortName}) ...");
            var regions = await _regionsService.GetRegionsAsync(regionName, regionShortName);

            return _mapper.Map<IEnumerable<Region>, IEnumerable<RegionResource>>(regions);
        }

        [HttpPost]
        public async Task<RegionResponse> AddRegionAsync([FromBody]AddRegionResource regionResource)
        {
            _logger.LogInformation($"Adding region (Name = {regionResource.Name}, ShortName = {regionResource.ShortName}) ...");

            var region = _mapper.Map<AddRegionResource, Region>(regionResource);
            var response = await _regionsService.AddRegionAsync(region);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<RegionResponse> UpdateRegionAsync(int id, [FromBody]AddRegionResource regionResource)
        {
            _logger.LogInformation($"Updating region #{id} (Name = {regionResource.Name}, ShortName = {regionResource.ShortName}) ...");

            var region = _mapper.Map<AddRegionResource, Region>(regionResource);
            var response = await _regionsService.UpdateRegionAsync(id, region);

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<RegionResponse> DeleteRegionAsync(int id)
        {
            _logger.LogInformation($"Deleting region #{id} ...");
            var response = await _regionsService.DeleteRegionAsync(id);

            return response;
        }
    }
}