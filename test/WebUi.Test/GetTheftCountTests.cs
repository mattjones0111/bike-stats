namespace WebUi.Test
{
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Doubles;
    using Helpers;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using NUnit.Framework;
    using Ports;

    public class GetTheftCountTests
    {
        HttpClient client;
        WebApplicationFactory<Startup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebUiApplicationFactory(services =>
            {
                services.Replace(
                    new ServiceDescriptor(
                        typeof(IGetTheftCounts),
                        typeof(StubTheftCountProvider),
                        ServiceLifetime.Transient));
            });
            client = factory.CreateClient();
        }

        [Test]
        public async Task GetTheftsReturnsExpectedResult()
        {
            XDocument htmlDocument = await LoadHtml("?location=Amsterdam");

            XElement resultSpan = htmlDocument
                .Descendants("span")
                .SingleOrDefault(x => x.Attribute("id")?.Value == "result");

            Assert.IsNotNull(resultSpan, "Result <span> was not found.");
            Assert.AreEqual("200", resultSpan.Value);
        }

        async Task<XDocument> LoadHtml(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            return XDocument.Load(responseStream);
        }

        [TearDown]
        public void Teardown()
        {
            client?.Dispose();
            factory?.Dispose();
        }
    }
}
