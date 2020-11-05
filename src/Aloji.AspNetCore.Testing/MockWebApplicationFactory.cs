using Aloji.AspNetCore.Testing.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Aloji.AspNetCore.Testing
{
    public class MockWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        public IMockFactory Mocks { get; private set; }
   
        public MockWebApplicationFactory(IMockFactory iMockFactory)
        {
            this.Mocks = iMockFactory 
                ?? throw new ArgumentNullException(nameof(iMockFactory));
        }

        public Action<IConfigurationBuilder> Configure { get; set; }

        protected override IHostBuilder CreateHostBuilder()
        {
            var configurationBuilder = new ConfigurationBuilder();
            this.Configure?.Invoke(configurationBuilder);
            var configuration = configurationBuilder.Build();

            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(host =>
                {
                    host.UseStartup<TStartup>()
                        .UseTestServer()
                        .ConfigureAppConfiguration(config =>
                        {
                            config.AddConfiguration(configuration);
                        });
                }).ConfigureServices(services => {
                    this.Mocks.Replace(services);
                });

            return builder;
        } 
    }
}
