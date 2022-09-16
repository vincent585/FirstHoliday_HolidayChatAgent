using AutoMapper;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Services.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<HolidayDto, HolidayDetail>();
        }
    }
}
