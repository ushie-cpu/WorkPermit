using AutoMapper;
using WorkPermitApp.Dtos.Request;
using WorkPermitApp.Dtos.Response;
using WorkPermitApp.Models;

namespace WorkPermitApp.Mapper
{
    public class MappingConfig
    {
        // this is used to Map the Dtos to the Model...
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // using the ReverseMap to do the mapping reversely
                config.CreateMap<WorkPermitsResponse, WorkPermit>().ReverseMap();
                config.CreateMap<WorkPermitRequestDto, WorkPermit>().ReverseMap();
                config.CreateMap<SiteCheckerRequestDto, SiteChecker>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
