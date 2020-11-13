using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public class MockBuilder : IMockBuilder
    {
        public IServiceCollection Services { get; private set; }
        public IList<Action<IServiceCollection, IServiceProvider>> ReplaceActions { get; private set; }

        public MockBuilder()
        {
            this.Services = new ServiceCollection();
            this.ReplaceActions = new List<Action<IServiceCollection, IServiceProvider>>();
        }

        public IMockFactory Build()
        {
            var result = new MockFactory(this.Services.BuildServiceProvider(), this.ReplaceActions);
            return result;
        }

        public virtual IMockBuilder AddMock<TService, TMock>()
            where TService : class
            where TMock : class, IMock<TService>
        {
            this.Services.AddSingleton<IMock<TService>, TMock>();
            this.Services.AddSingleton<IMock>((p) => (IMock)p.GetService<IMock<TService>>());

            this.ReplaceActions.Add((testService, mockProvider) => {
                testService.RemoveAll<TService>();
                testService.AddSingleton<TService>(mockProvider.GetService<IMock<TService>>().Instance);
            });

            return this;
        }
    }
}
