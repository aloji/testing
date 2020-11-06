using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TodoApi.Tests.Mocks.Options;

namespace TodoApi.Tests.Mocks.Extensions
{
    public static class MockBuilderExtensions
    {
        public static IMockBuilder AddMocks(this IMockBuilder mockBuilder)
        {
            if (mockBuilder == null)
                return mockBuilder;

            var configuration = LoadConfig();

            mockBuilder.AddMock<IForecastRepository, ForecastRepositoryMock>();
            mockBuilder.Services.AddOptions<ForecastServiceOptions>()
                    .Bind(configuration.GetSection(ForecastServiceOptions.SectionKey));

            return mockBuilder;
        }

        private static IConfiguration LoadConfig()
        {
            var result = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("default_forecast_service.json", true)
                .Build();
            return result;
        }
    }
}
