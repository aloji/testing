using Aloji.AspNetCore.Testing;
using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.Configuration;
using TodoApi.net5._0;
using TodoApi.Tests.net5._0.Mocks.Extensions;

namespace TodoApi.Tests.net5._0
{
    public class TodoApiMockWebApplicationFactory : MockWebApplicationFactory<Startup>
    {
        public TodoApiMockWebApplicationFactory() 
            : base(new MockBuilder()
                  .AddMocks()
                  .Build())
        {
            this.Configure = (c) => c.AddEnvironmentVariables();
        }
    }
}
