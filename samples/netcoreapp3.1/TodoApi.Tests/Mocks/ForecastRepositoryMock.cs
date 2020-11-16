using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.Options;
using NSubstitute;
using TodoApi.Tests.Mocks.Options;

namespace TodoApi.Tests.Mocks
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
