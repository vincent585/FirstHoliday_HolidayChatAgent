using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using HolidayChatAgent.Mappings;
using HolidayChatAgent.Models;
using HolidayChatAgent.Services.Mappings;
using HolidayChatAgent.Services.Models.Domain;
using NUnit.Framework;

namespace HolidayChatAgent.Tests.MappingsTests
{
    public class ViewModelMappingTests : MappingTests
    {
        private Fixture _fixture;
        private IMapper _mapper;

        [OneTimeSetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapper = Setup<ViewModelMappings>();
        }

        [Test]
        public void Mapper_WhenCalled_MapsHolidayDetailToHolidayViewModel()
        {
            var dto = _fixture.Create<HolidayDetail>();

            var result = _mapper.Map<HolidayViewModel>(dto);

            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                result.HotelName.Should().Be(dto.HotelName);
                result.City.Should().Be(dto.City);
                result.Continent.Should().Be(dto.Continent);
                result.Country.Should().Be(dto.Country);
                result.Category.Should().Be(dto.Category);
                result.StarRating.Should().Be(dto.StarRating);
                result.TempRating.Should().Be(dto.TempRating);
                result.Location.Should().Be(dto.Location);
                result.PricePerNight.Should().Be(dto.PricePerNight);
            }
        }
    }
}
