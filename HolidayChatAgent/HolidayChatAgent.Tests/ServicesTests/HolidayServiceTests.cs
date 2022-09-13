using AutoFixture;
using AutoMapper;
using FluentAssertions;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Repository.Interfaces;
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
        private HolidayService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapperMock = new Mock<IMapper>();
            _holidayRepositoryMock = new Mock<IHolidayRepository>();
            _sut = new HolidayService(_mapperMock.Object, _holidayRepositoryMock.Object);
        }

        [Test]
        public void Constructor_WhenMapperParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(null, _holidayRepositoryMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mapper");
        }

        [Test]
        public void Constructor_WhenRepositoryParameterIsNull_ArgumentNullExceptionShouldBeThrown()
        {
            var constructor = () => new HolidayService(_mapperMock.Object, null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayRepository");
        }

        [Test]
        public async Task GetRecommendedHolidaysAsync_WhenCalled_CallsHolidayRepository()
        {
            await _sut.GetRecommendedHolidaysAsync();

            _holidayRepositoryMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }
    }
}
