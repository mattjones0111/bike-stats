namespace WebUi.Test.Doubles
{
    using System;
    using System.Threading.Tasks;
    using Ports;

    /// <summary>
    ///    A substitute theft count provider which returns a result of 200
    ///    if the location is "Amsterdam", 0 for everywhere else.
    /// </summary>
    public sealed class StubTheftCountProvider : IGetTheftCounts
    {
        public Task<int> GetTheftCountAsync(string locationName)
        {
            int result = 0;

            if (string.Equals(
                locationName,
                "Amsterdam",
                StringComparison.InvariantCultureIgnoreCase))
            {
                result = 200;
            }

            return Task.FromResult(result);
        }
    }
}
