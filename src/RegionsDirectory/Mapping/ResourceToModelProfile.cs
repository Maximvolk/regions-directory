using RegionsDirectory.Core.Models;
using RegionsDirectory.Resources;
using AutoMapper;

namespace RegionsDirectory.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<RegionResource, Region>();
        }
    }
}