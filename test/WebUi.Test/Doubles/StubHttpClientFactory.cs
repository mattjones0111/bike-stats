namespace WebUi.Test.Doubles
{
    using System;
    using System.Net.Http;

    public class StubHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            HttpClient client = new HttpClient(new StubErroringDelegatingHandler())
            {
                BaseAddress = new Uri("http://some.url/incidents")
            };

            return client;
        }
    }
}