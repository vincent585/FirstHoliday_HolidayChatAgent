using System.Net;
using AutoFixture;
using FluentAssertions;
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
        private Mock<IHolidayService> _holidayServiceMock;
        private Fixture _fixture;
        private HomeController _sut;

        [SetUp]
        public void Setup()
        {
            _holidayServiceMock = new Mock<IHolidayService>();
            _fixture = new Fixture();
            _sut = new HomeController(_holidayServiceMock.Object);
        }

        [Test]
        public void Constructor_WhenHolidayServiceIsNull_ThrowsArgumentNullException()
        {
            var constructor = () => new HomeController(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("holidayService");
        }

        [Test]
        public async Task Index_WhenCalled_CallsHolidayServiceOnce()
        {
            await _sut.Index();

            _holidayServiceMock.Verify(x => x.GetAllHolidaysAsync(), Times.Once);
        }

        [Test]
        public async Task Index_WhenCalled_CallsViewWithCorrectViewModel()
        {
            var holidayDetails = _fixture.CreateMany<HolidayDetail>();
            var expectedViewModel = _fixture.Build<HolidayViewModel>()
                .With(x => x.Holidays, holidayDetails)
                .With(x => x.UserPreferences, new UserPreferences())
                .Create();
            

            _holidayServiceMock.Setup(x => x.GetAllHolidaysAsync()).ReturnsAsync(holidayDetails);


            var result = await _sut.Index() as ViewResult;

            result.Model.Should().BeEquivalentTo(expectedViewModel);
        }

        [Test]
        public async Task Details_WhenCalled_CallsHolidayServiceOnce()
        {
            await _sut.Details(It.IsAny<int>());

            _holidayServiceMock.Verify(x => x.GetHolidayByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task Details_WhenHolidayNotFound_ReturnsNotFound()
        {
            _holidayServiceMock.Setup(x => x.GetHolidayByIdAsync(It.IsAny<int>()))!.ReturnsAsync((HolidayDetail)null!);

            var result = await _sut.Details(It.IsAny<int>()) as NotFoundResult;

            result.StatusCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public async Task Details_WhenHolidayFound_CallsDetailsViewWithCorrectModel()
        {
            var holiday = _fixture.Create<HolidayDetail>();

            _holidayServiceMock.Setup(x => x.GetHolidayByIdAsync(It.IsAny<int>())).ReturnsAsync(holiday);

            var result = await _sut.Details(It.IsAny<int>()) as ViewResult;

            result.Model.Should().Be(holiday);
        }

        [Test]
        public async Task RecommendedHolidays_WhenCalled_CallsHolidayService()
        {
            await _sut.RecommendedHolidays(It.IsAny<UserPreferences>());

            _holidayServiceMock.Verify(x => x.GetRecommendedHolidaysAsync(It.IsAny<UserPreferences>()), Times.Once);
        }

        [Test]
        public async Task RecommendedHolidays_WhenCalled_CallsViewWithCorrectModel()
        {
            var holidayDetails = _fixture.CreateMany<HolidayDetail>();
            var expectedViewModel = _fixture.Build<HolidayViewModel>()
                .With(x => x.Holidays, holidayDetails)
                .With(x => x.UserPreferences, It.IsAny<UserPreferences>())
                .Create();


            _holidayServiceMock.Setup(x => x.GetRecommendedHolidaysAsync(It.IsAny<UserPreferences>())).ReturnsAsync(holidayDetails);

            var result = await _sut.RecommendedHolidays(It.IsAny<UserPreferences>()) as ViewResult;

            result.Model.Should().BeEquivalentTo(expectedViewModel);
        }
    }
}
