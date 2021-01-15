using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace WebUi.Test
{
    public class WebUiTests
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [Test]
        public async Task CanHitHomepage()
        {
            HttpResponseMessage response = await _client.GetAsync("");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TearDown]
        public void Teardown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }
    }
}
