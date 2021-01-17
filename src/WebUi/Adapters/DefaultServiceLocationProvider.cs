namespace WebUi.Adapters
{
    using System.Threading.Tasks;
    using Ports;

    /// <summary>
    ///    A provider that returns a fixed list of current and future
    ///    service locations.
    /// </summary>
    public sealed class DefaultServiceLocationProvider : IProvideServiceLocations
    {
        public Task<string[]> GetServiceLocationsAsync()
        {
            string[] result = { 
                "Amsterdam", "Berlin", "Copenhagen",
                "Brussels", "Milan", "London", "Paris"
            };

            return Task.FromResult(result);
        }
    }
}
