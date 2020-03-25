using IntegrationTestingExample;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntegrationTestingExampleTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider
                var serviceProvider = new ServiceCollection()
                    .BuildServiceProvider();

                // Build the service provider.
                var sp = services.BuildServiceProvider();
            });
        }
    }
}