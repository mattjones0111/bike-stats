namespace WebUi.Test
{
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Helpers;
    using Microsoft.AspNetCore.Mvc.Testing;
    using NUnit.Framework;

    public class DropdownListOfAvailableLocationsTest
    {
        HttpClient client;
        WebApplicationFactory<Startup> factory;

        [SetUp]
        public void Setup()
        {
            factory = new WebUiApplicationFactory();
            client = factory.CreateClient();
        }

        [Test]
        public async Task Test()
        {
            HttpResponseMessage response = await client.GetAsync("");

            Stream responseStream = await response.Content.ReadAsStreamAsync();
            XDocument htmlDocument = XDocument.Load(responseStream);

            XElement dropdown = htmlDocument.Descendants("select").SingleOrDefault();

            Assert.IsNotNull(dropdown, "Location dropdown not found.");
        }

        [TearDown]
        public void Teardown()
        {
            client?.Dispose();
            factory?.Dispose();
        }
    }
}