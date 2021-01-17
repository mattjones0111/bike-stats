namespace WebUi.Adapters
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Configuration;
    using Ports;

    /// <summary>
    ///    A provider that uses the Bikewise API to retrieve counts of
    ///    theft incidents.
    /// </summary>
    public sealed class BikewiseApiTheftCountProvider : IGetTheftCounts
    {
        readonly HttpClient httpClient;

        public BikewiseApiTheftCountProvider(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(HttpClientNames.Bikewise);
        }

        public async Task<int> GetTheftCountAsync(string locationName)
        {
            string query = "?page=1&" +
                           $"proximity={locationName}" +
                           "&incident_type=theft";

            HttpResponseMessage response = await httpClient.GetAsync(query);

            if (!response.IsSuccessStatusCode)
            {
                throw new BikewiseApiException(
                    query,
                    "Bikewise API returned a non-success status code.",
                    response.StatusCode);
            }

            string[] totalHeader = response.Headers
                .GetValues("Total")
                .ToArray();

            if (totalHeader.Length != 1)
            {
                throw new BikewiseApiException(
                    query,
                    "Zero or non-unique 'Total' header(s) returned.",
                    response.StatusCode);
            }

            if (!int.TryParse(totalHeader.Single(), out int result))
            {
                throw new BikewiseApiException(
                    query,
                    "Non-numeric 'Total' header returned.",
                    response.StatusCode);
            }

            return result;
        }
    }
}
