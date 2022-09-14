using AutoFixture;
using AutoMapper;
using FluentAssertions;
using HolidayChatAgent.Repository.Interfaces;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;
using HolidayChatAgent.Services.Services;
using Moq;
using NUnit.Framework;

namespace HolidayChatAgent.Tests.ServicesTests
{
    [TestFixture]
    public class HolidayServiceTests
    {
        private Fixture _fixture;
        private Mock<IHolidayRepository> _holidayRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IHolidayFilter> _holidayFilterMock;
        private HolidayService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapperMock = new Mock<IMapper>();
            _holidayRepositoryMock = new Mock<IHolidayRepository>();
            _holidayFilterMock = new Mock<IHolidayFilter>();
            _sut = new HolidayService(_mapperMock.Object, _holidayRepositoryMock.Object, _holidayFilterMock.Object);
        }

        [Test]
        public void Constructor_WhenMapperParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(null, _holidayRepositoryMock.Object, _holidayFilterMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mapper");
        }

        [Test]
        public void Constructor_WhenRepositoryParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(_mapperMock.Object, null, _holidayFilterMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayRepository");
        }

        [Test]
        public void Constructor_WhenFilterParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(_mapperMock.Object, _holidayRepositoryMock.Object, null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayFilter");
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_CallsHolidayRepository()
        {
            var preferences = _fixture.Create<UserPreferences>();
            await _sut.GetRecommendedHolidaysAsync(preferences);

            _holidayRepositoryMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }
    }
}
