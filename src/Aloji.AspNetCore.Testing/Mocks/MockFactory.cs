using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public class MockFactory : IMockFactory
    {
        private readonly ServiceProvider serviceProvider;
        private readonly IEnumerable<Action<IServiceCollection, IServiceProvider>> replaceActions;

        public MockFactory(ServiceProvider serviceProvider, 
            IEnumerable<Action<IServiceCollection, IServiceProvider>> replaceActions)
        {
            this.serviceProvider = serviceProvider 
                ?? throw new ArgumentNullException(nameof(serviceProvider));

            this.replaceActions = replaceActions;
        }

        public TService Get<TService>()
            where TService : class
        {
            var iMock = this.serviceProvider.GetService<IMock<TService>>();
            if (iMock == default)
                return default;
            return iMock.Instance;
        }

        public void Clear()
        {
            var iMocks = this.serviceProvider.GetServices<IMock>();
            foreach (var item in iMocks)
                item.Clear();
        }

        public void Replace(IServiceCollection apiServices)
        {
            if (this.replaceActions == null)
                return;
            foreach (var action in this.replaceActions)
            {
                action(apiServices, this.serviceProvider);
            }
        }
    }
}
