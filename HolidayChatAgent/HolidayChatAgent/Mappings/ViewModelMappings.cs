using AutoMapper;
using HolidayChatAgent.Models;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Services.Models.Domain;

namespace HolidayChatAgent.Mappings
{
    public class ViewModelMappings : Profile
    {
        public ViewModelMappings()
        {
            CreateMap<HolidayDetail, HolidayViewModel>();
        }
    }
}
