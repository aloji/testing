using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Aloji.AspNetCore.Testing.UnitTests.MockFactoryTests
{
    public class GetTests
    {
        [Fact]
        public void Should_Return_Null_IfServiceNotRegister()
        {
            var serviceProvider = new ServiceCollection()
              .BuildServiceProvider();

            var factory = new MockFactory(serviceProvider, null);

            var actual = factory.Get<IService>();
            Assert.Null(actual);
        }

        [Fact]
        public void Should_Return_Service_IfIMockServiceIsRegister()
        {
            var expected = Substitute.For<IService>();
            var mock = Substitute.For<IMock<IService>>();
            mock.Instance.Returns(expected);

            var serviceProvider = new ServiceCollection()
                .AddSingleton((p) => mock)
                .BuildServiceProvider();

            var factory = new MockFactory(serviceProvider, null);

            var actual = factory.Get<IService>();

            mock.Instance.Received(1);
            Assert.NotNull(actual);
            Assert.Equal(expected, actual);
        }
    }
}
