using RegionsDirectory.Core.Models;
using RegionsDirectory.Resources;
using AutoMapper;

namespace RegionsDirectory.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Region, RegionResource>();
        }
    }
}