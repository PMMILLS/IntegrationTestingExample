using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntegrationTestingExample;   
using Newtonsoft.Json;
using NUnit.Framework;

namespace IntegrationTestingExampleTests.Controllers
{
    [TestFixture]
    public class TestControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new CustomWebApplicationFactory<Startup>().CreateClient();
        }

        [Test]
        public async Task Verify_ResultFrom_Client()
        {
            // The endpoint or route of the controller action.
            HttpResponseMessage httpResponse = await _client.GetAsync("/test");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            string stringResponse = await httpResponse.Content.ReadAsStringAsync();
            List<string> result = JsonConvert.DeserializeObject<List<string>>(stringResponse);

            // Assert some stuff
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Hello", result[0]);
                Assert.AreEqual("World", result[1]); 
                Assert.AreEqual("!", result[2]);
            });
        }

        [Test]
        public async Task Verify_ClientCall_IsSuccess()
        {
            // The endpoint or route of the controller action.
            HttpResponseMessage httpResponse = await _client.GetAsync("/test");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Assert some stuff
            Assert.IsTrue(httpResponse.IsSuccessStatusCode);
        }
    }
}