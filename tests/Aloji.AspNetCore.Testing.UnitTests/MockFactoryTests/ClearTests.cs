using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Aloji.AspNetCore.Testing.UnitTests.MockFactoryTests
{
    public class ClearTests
    {
        [Fact]
        public void Should_Invoke_MockClears()
        {
            var count = 0;

            var mock = Substitute.For<IMock>();
            mock.When((m) => m.Clear())
                .Do((x) => count++);

            var serviceProvider = new ServiceCollection()
                .AddSingleton((p) => mock)
                .BuildServiceProvider();

            var factory = new MockFactory(serviceProvider, null);

            factory.Clear();

            mock.Received(1);
            Assert.Equal(1, count);
        }
    }
}
