using NUnit.Framework;
using FluentAssertions;
using HolidayChatAgent.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HolidayChatAgent.Tests
{
    [TestFixture]
    public class ServiceCollectionExtensionTests
    {
        [Test]
        public void AddApplication_WhenCalled_ConfiguresValidContainer()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddApplication();


            serviceCollection.Invoking(sc => sc.BuildServiceProvider(true)).Should().NotThrow();
        }
    }
}
