namespace WebUi.Test
{
    using System.Collections.Generic;
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
        public async Task DropdownExists()
        {
            XDocument htmlDocument = await LoadHtml("");

            XElement dropdown = htmlDocument
                .Descendants("select")
                .SingleOrDefault();

            Assert.IsNotNull(dropdown, "Location dropdown not found.");
        }

        [Test]
        public async Task DropdownContainsLocations()
        {
            XDocument htmlDocument = await LoadHtml("");

            IEnumerable<string> actual = htmlDocument
                .Descendants("select")
                .Single()
                .Descendants("option")
                .Select(x => x.Value);

            string[] expected =
            {
                "Amsterdam", "Berlin", "Copenhagen",
                "Brussels", "Milan", "Paris", "London"
            };

            CollectionAssert.AreEquivalent(
                expected,
                actual,
                "Location dropdown does not contain expected cities.");
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
