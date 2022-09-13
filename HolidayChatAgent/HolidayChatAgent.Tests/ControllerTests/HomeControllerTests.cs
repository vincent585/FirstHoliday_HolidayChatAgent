using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using HolidayChatAgent.Controllers;
using HolidayChatAgent.Models;
using HolidayChatAgent.Services.Interfaces;
using HolidayChatAgent.Services.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace HolidayChatAgent.Tests.ControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IHolidayService> _holidayServiceMock;
        private Fixture _fixture;
        private HomeController _sut;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _holidayServiceMock = new Mock<IHolidayService>();
            _fixture = new Fixture();
            _sut = new HomeController(_holidayServiceMock.Object, _mapperMock.Object);
        }

        [Test]
        public void Constructor_WhenHolidayServiceIsNull_ThrowsArgumentNullException()
        {
            var constructor = () => new HomeController(null, _mapperMock.Object);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayService");
        }

        [Test]
        public void Constructor_MapperIsNull_ThrowsArgumentNullException()
        {
            var constructor = () => new HomeController(_holidayServiceMock.Object, null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mapper");
        }

        [Test]
        public async Task Index_WhenCalled_CallsHolidayServiceOnce()
        {
            await _sut.Index();

            _holidayServiceMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }

        [Test]
        public async Task Index_WhenCalled_CallsMapperOnce()
        {
            await _sut.Index();

            _mapperMock.Verify(x => x.Map<IEnumerable<HolidayViewModel>>(It.IsAny<IEnumerable<HolidayDetail>>()), Times.Once);
        }

        [Test]
        public async Task Index_WhenCalled_CallsViewWithCorrectViewModel()
        {
            var expectedViewModel = _fixture.CreateMany<HolidayViewModel>();
            var holidayDetails = _fixture.CreateMany<HolidayDetail>();

            _holidayServiceMock.Setup(x => x.GetAllHolidaysAsync()).ReturnsAsync(holidayDetails);

            _mapperMock.Setup(x => x.Map<IEnumerable<HolidayViewModel>>(holidayDetails))
                .Returns(expectedViewModel);

            var result = await _sut.Index() as ViewResult;
            using (new AssertionScope())
            {
                result.ViewName.Should().Be("Index");
                result.Model.Should().BeEquivalentTo(expectedViewModel);
            }
            
        }
    }
}
