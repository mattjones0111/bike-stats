namespace WebUi.Adapters
{
    using System.Threading.Tasks;
    using Ports;

    public sealed class CurrentServiceLocationsProvider : IProvideServiceLocations
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
