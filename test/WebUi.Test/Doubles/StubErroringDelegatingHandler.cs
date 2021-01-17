namespace WebUi.Test.Doubles
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    ///    A stub <see cref="DelegatingHandler"/> to allow the behaviour
    ///    of the BikewiseApiClient to be exercised for different scenarios
    ///    of failure.
    /// </summary>
    public class StubErroringDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

            NameValueCollection queryParams =
                HttpUtility.ParseQueryString(request.RequestUri.Query);

            string proximity = queryParams["proximity"];

            if (string.Equals(
                proximity,
                "ServerError",
                StringComparison.InvariantCultureIgnoreCase))
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
            }

            if (string.Equals(
                proximity,
                "HappyPath",
                StringComparison.InvariantCultureIgnoreCase))
            {
                response.Headers.Add("Total", "123");
            }

            if (string.Equals(
                proximity,
                "NonNumeric",
                StringComparison.InvariantCultureIgnoreCase))
            {
                response.Headers.Add("Total", "SomethingOrOther");
            }

            if (string.Equals(
                proximity,
                "Multiple",
                StringComparison.InvariantCultureIgnoreCase))
            {
                response.Headers.Add("Total", "123");
                response.Headers.Add("Total", "456");
            }

            return Task.FromResult(response);
        }
    }
}
