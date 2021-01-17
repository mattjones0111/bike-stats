namespace WebUi.Configuration
{
    using System;
    using Adapters;
    using Microsoft.Extensions.DependencyInjection;
    using Ports;

    public static class BikewiseApiExtensions
    {
        public static IServiceCollection AddBikewiseApi(
            this IServiceCollection services,
            string incidentsUrl)
        {
            if (string.IsNullOrWhiteSpace(incidentsUrl))
            {
                throw new ArgumentException($"{nameof(incidentsUrl)} is not set.");
            }

            services.AddTransient<IGetTheftCounts, BikewiseApiTheftCountProvider>();

            services.AddHttpClient(
                HttpClientNames.Bikewise,
                client =>
                {
                    client.BaseAddress = new Uri("https://bikewise.org/api/v2/incidents");
                });

            return services;
        }
    }
}
