namespace WebUi.Ports
{
    using System.Threading.Tasks;

    public interface IProvideServiceLocations
    {
        Task<string[]> GetServiceLocationsAsync();
    }
}
