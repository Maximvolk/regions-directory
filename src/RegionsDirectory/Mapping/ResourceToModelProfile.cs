using RegionsDirectory.Core.Models;
using RegionsDirectory.Common.Resources;
using AutoMapper;

namespace RegionsDirectory.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegionResource, Region>();
            CreateMap<AddRegionResource, Region>();
        }
    }
}