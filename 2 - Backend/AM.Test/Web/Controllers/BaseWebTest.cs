using AM.Service;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace AM.UnitTests.Web.Controllers
{
    public class BaseWebTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient _client;

        public BaseWebTest(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        // write tests that use _client
    }
}
