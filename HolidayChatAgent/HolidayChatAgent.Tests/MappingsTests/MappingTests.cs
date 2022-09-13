using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AutoMapper;

namespace HolidayChatAgent.Tests.MappingsTests
{
    [ExcludeFromCodeCoverage]
    public abstract class MappingTests
    {
        protected IMapper Setup<T>(params Profile[] childProfiles) where T : Profile, new()
        {
            var assembly = typeof(T).Assembly;
            var types = assembly.GetTypes().Where(t => t.BaseType == typeof(Profile));
            var mapper = new Mapper(new MapperConfiguration(config =>
            {
                foreach (var type in types)
                {
                    config.AddProfile(type);
                }

                foreach (var childProfile in childProfiles)
                {
                    config.AddProfile(childProfile);
                }
            }));
            return mapper;
        }

        protected int GetPropertyCount<T>() where T : class
        {
            return typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length;
        }

        protected class MockChildMapper<TSrc, TDest> : Profile
        {
            public MockChildMapper(TDest destinationObj)
            {
                CreateMap<TSrc, TDest>()
                    .ConvertUsing(src => destinationObj);
            }
        }
    }
}
