namespace WebUi.Adapters
{
    using System;
    using System.Threading.Tasks;
    using Ports;

    public class NopTheftCountProvider : IGetTheftCounts
    {
        public Task<int> GetTheftCountAsync(string locationName)
        {
            throw new NotImplementedException();
        }
    }
}
