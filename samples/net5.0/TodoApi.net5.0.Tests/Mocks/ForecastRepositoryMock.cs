using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.Options;
using NSubstitute;
using TodoApi.net5._0;
using TodoApi.Tests.net5._0.Mocks.Options;

namespace TodoApi.Tests.net5._0.Mocks
{
    public class ForecastRepositoryMock : NSubstituteMock<IForecastRepository>
    {
        public ForecastRepositoryMock(IOptionsMonitor<ForecastServiceOptions> options)
            : base((instance) => {
                instance.Get().Returns(options.CurrentValue.Get);
            })
        {
        }
    }
}
