
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IntegrationTestingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Hello", "World", "!"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Summaries;
        }

        [HttpGet]
        [Route("[action]")]
        public void XPOCall()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://apidev.ltl.xpo.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Bearer 0012f2fe227b5616ce4b79fafb71c97e");

            StringContent content = new StringContent("");
            HttpResponseMessage response = client.PostAsync("claims/1.0/claims/third-parties", content).Result;
        }
    }
}
