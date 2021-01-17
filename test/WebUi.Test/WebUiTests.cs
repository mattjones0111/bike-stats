namespace WebUi.Test
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Testing;
    using NUnit.Framework;

    public class WebUiTests
    {
        HttpClient client;
        WebApplicationFactory<Startup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [Test]
        public async Task CanHitHomepage()
        {
            HttpResponseMessage response = await client.GetAsync("");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TearDown]
        public void Teardown()
        {
            client?.Dispose();
            factory?.Dispose();
        }
    }
}