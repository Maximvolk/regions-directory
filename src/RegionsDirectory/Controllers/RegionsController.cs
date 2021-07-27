using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RegionsDirectory.Core.Interfaces.Services;
using RegionsDirectory.Common.Resources;
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
        public async Task<RegionResource[]> GetRegionsAsync([FromQuery]string regionName)
        {
            return new RegionResource[1]
                {new RegionResource {Id = 1, Name = "sample", ShortName = "s1"}};
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync([FromBody]RegionResource region)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegionAsync(int id, [FromBody]RegionResource region)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegionAsync(int id)
        {
            return Ok();
        }
    }
}