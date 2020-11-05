using Aloji.AspNetCore.Testing;
using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.Extensions.Configuration;
using TodoApi.Tests.Mocks;

namespace TodoApi.Tests
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
