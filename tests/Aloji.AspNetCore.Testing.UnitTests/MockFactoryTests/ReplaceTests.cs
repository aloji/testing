using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace Aloji.AspNetCore.Testing.UnitTests.MockFactoryTests
{
    public class ReplaceTests
    {
        [Fact]
        public void Should_Invoke_ReplaceActions()
        {
            var count = 0;
            
            var mockServiceProvider = new ServiceCollection()
                .BuildServiceProvider();

            var apiServiceCollection = new ServiceCollection();

            var action = Substitute.For<Action<IServiceCollection, IServiceProvider>>();
            action.When(a => a.Invoke(apiServiceCollection, mockServiceProvider))
                .Do((x) => count++);

            var replaceActions = new List<Action<IServiceCollection, IServiceProvider>>()
            {
                action
            };
            var factory = new MockFactory(mockServiceProvider, replaceActions);

            factory.Replace(apiServiceCollection);

            Assert.Equal(1, count);
        }
    }
}
