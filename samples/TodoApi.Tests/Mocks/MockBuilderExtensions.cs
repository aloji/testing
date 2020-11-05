using Aloji.AspNetCore.Testing.Mocks;

namespace TodoApi.Tests.Mocks
{
    public static class MockBuilderExtensions
    {
        public static IMockBuilder AddMocks(this IMockBuilder mockBuilder)
        {
            if(mockBuilder != null)
                mockBuilder.AddMock<IForecastService, ForecastServiceMock>();
            return mockBuilder;
        }
    }
}
