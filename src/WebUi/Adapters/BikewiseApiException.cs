namespace WebUi.Adapters
{
    using System;
    using System.Net;

    /// <summary>
    ///    An exception that is thrown when an unexpected result is returned
    ///    from the Bikewise API.
    /// </summary>
    public class BikewiseApiException : Exception
    {
        public string Query { get; }
        public HttpStatusCode StatusCode { get; }

        public BikewiseApiException(
            string query,
            string message,
            HttpStatusCode code) : base(message)
        {
            Query = query;
            StatusCode = code;
        }
    }
}
