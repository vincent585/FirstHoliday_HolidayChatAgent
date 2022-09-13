using System.Data;
using AutoFixture;
using FluentAssertions;
using HolidayChatAgent.Repository.DbConnection;
using HolidayChatAgent.Repository.DTOs;
using HolidayChatAgent.Repository.Repositories;
using Moq;
using NUnit.Framework;

namespace HolidayChatAgent.Tests.RepositoryTests
{
    [TestFixture]
    public class HolidayRepositoryTests
    {
        [Test]
        public void Constructor_WhenDbConnectionFactoryIsNull_ThrowsArgumentNullException()
        {
            var constructor = () => new HolidayRepository(null);

            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("dbConnectionFactory");
        }
    }
}
