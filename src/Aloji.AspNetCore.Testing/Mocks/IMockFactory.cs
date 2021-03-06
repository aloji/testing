﻿using Microsoft.Extensions.DependencyInjection;

namespace Aloji.AspNetCore.Testing.Mocks
{
    public interface IMockFactory
    {
        TService Get<TService>() where TService : class;
        void Clear();
        void Replace(IServiceCollection apiServices);
    }
}
