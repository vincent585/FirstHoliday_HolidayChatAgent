using AutoMapper;
using HolidayChatAgent.Repository.DbConnection;
using HolidayChatAgent.Repository.Interfaces;
using HolidayChatAgent.Repository.Repositories;
using HolidayChatAgent.Services.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace HolidayChatAgent.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddSingleton(new MapperConfiguration(c =>
            {
                c.AddProfile<ApplicationMappings>();
            }));
        }
    }
}