namespace WebUi.Test
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Helpers;
    using NUnit.Framework;

    public class CanHitHomepageTest
    {
        HttpClient client;
        WebUiApplicationFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebUiApplicationFactory();
            client = factory.CreateClient();
        }

        [Test]
        public async Task HomepageExists()
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
