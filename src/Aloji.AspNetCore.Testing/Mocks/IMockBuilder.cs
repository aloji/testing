using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public interface IMockBuilder
    {
        IServiceCollection Services { get; }
        IList<Action<IServiceCollection, IServiceProvider>> ReplaceActions { get; }

        IMockBuilder AddMock<TService, TMock>()
            where TService : class
            where TMock : class, IMock<TService>;

        IMockFactory Build();
    }
}
