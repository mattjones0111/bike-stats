namespace WebUi.Test.Helpers
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.TestHost;
    using Microsoft.Extensions.DependencyInjection;

    public class WebUiApplicationFactory : WebApplicationFactory<Startup>
    {
        public Action<IServiceCollection> ConfigureTestServices { get; }

        public WebUiApplicationFactory(
            Action<IServiceCollection> configureTestServices = null)
        {
            ConfigureTestServices = configureTestServices;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            if (ConfigureTestServices != null)
            {
                builder.ConfigureTestServices(ConfigureTestServices);
            }
        }
    }
}