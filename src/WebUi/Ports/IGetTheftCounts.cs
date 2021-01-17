namespace WebUi.Ports
{
    using System.Threading.Tasks;

    public interface IGetTheftCounts
    {
        Task<int> GetTheftCountAsync(string locationName);
    }
}
