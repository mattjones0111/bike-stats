namespace WebUi.Test
{
    using System.Net;
    using System.Threading.Tasks;
    using Adapters;
    using Doubles;
    using NUnit.Framework;

    public class BikewiseApiClientTests
    {
        BikewiseApiClient subject;

        [SetUp]
        public void Setup()
        {
            subject = new BikewiseApiClient(new StubHttpClientFactory());
        }

        [Test]
        public async Task ReturnsContentsOfTotalHeader()
        {
            int result = await subject.GetTheftCountAsync("HappyPath");

            Assert.AreEqual(123, result);
        }

        [Test]
        public void ExceptionThrownWith500StatusCode()
        {
            BikewiseApiException exception = Assert.ThrowsAsync<BikewiseApiException>(
                () => subject.GetTheftCountAsync("ServerError"));

            Assert.IsNotNull(exception);
            Assert.AreEqual(HttpStatusCode.InternalServerError, exception.StatusCode);
        }

        [Test]
        public void ExceptionThrownWithMultipleHeaders()
        {
            Assert.ThrowsAsync<BikewiseApiException>(
                () => subject.GetTheftCountAsync("Multiple"));
        }

        [Test]
        public void ExceptionThrownWithNoTotalHeader()
        {
            Assert.ThrowsAsync<BikewiseApiException>(
                () => subject.GetTheftCountAsync("NoHeader"));
        }

        [Test]
        public void ExceptionThrownWithNonNumericHeader()
        {
            Assert.ThrowsAsync<BikewiseApiException>(
                () => subject.GetTheftCountAsync("NonNumeric"));
        }
    }
}
