using Aloji.AspNetCore.Testing.Mocks;
using System;
using Xunit;

namespace Aloji.AspNetCore.Testing.UnitTests.MockBuilderTests
{
    public class AddMockTests
    {
        private class ServiceMock : IMock<IService>
        {
            public IService Instance => throw new NotImplementedException();

            public void Clear()
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Should_AddToServiceCollection_and_AddReplaceActions()
        {
            var builder = new MockBuilder();
            builder.AddMock<IService, ServiceMock>();

            Assert.Equal(1, builder.ReplaceActions.Count);
            Assert.Equal(2, builder.Services.Count);
        }
    }
}
