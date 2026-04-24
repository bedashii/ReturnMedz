using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FlowinglySDC.API.Controllers;
using FlowinglySDC.Web.Pages;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FlowinglySDC.Web.Tests
{
    public class IndexPageTests : IClassFixture<IndexPageTests.IntegrationTestFixture>
    {
        private readonly HttpClient _webClient;

        public IndexPageTests(IntegrationTestFixture fixture)
        {
            _webClient = fixture.WebClient;
        }

        #region Validate Handler Tests

        [Fact]
        public async Task OnPostValidate_ValidData_ReturnsIsValidTrue()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Validate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.True(doc.RootElement.GetProperty("isValid").GetBoolean());
            Assert.Equal("DEV632", doc.RootElement.GetProperty("costCentreDescription").GetString());
            Assert.Equal(1024.01m, doc.RootElement.GetProperty("totalCost").GetDecimal());
        }

        [Fact]
        public async Task OnPostValidate_MissingTotalTag_ReturnsIsValidFalse()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Validate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.False(doc.RootElement.GetProperty("isValid").GetBoolean());
        }

        [Fact]
        public async Task OnPostValidate_InvalidXmlTag_ReturnsIsValidFalse()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</expense>";

            var response = await PostToHandler("Validate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.False(doc.RootElement.GetProperty("isValid").GetBoolean());
        }

        [Fact]
        public async Task OnPostValidate_MissingCostCentre_ReturnsCostCentreUnknown()
        {
            var message = "<expense><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Validate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.Equal("UNKNOWN", doc.RootElement.GetProperty("costCentreDescription").GetString());
        }

        #endregion

        #region Calculate Handler Tests

        [Fact]
        public async Task OnPostCalculate_ValidData_ReturnsCalculatedJson()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Calculate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.True(doc.RootElement.TryGetProperty("SalesTaxValue", out _));
            Assert.True(doc.RootElement.TryGetProperty("TotalExcludingSalesTax", out _));
            Assert.Equal("DEV632", doc.RootElement.GetProperty("CostCentreDescription").GetString());
        }

        [Fact]
        public async Task OnPostCalculate_MissingTotalTag_ReturnsZeroValues()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Calculate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.Equal(0m, doc.RootElement.GetProperty("SalesTaxValue").GetDecimal());
            Assert.Equal(0m, doc.RootElement.GetProperty("TotalExcludingSalesTax").GetDecimal());
        }

        [Fact]
        public async Task OnPostCalculate_InvalidXmlTag_ReturnsZeroValues()
        {
            var message = "<expense><cost_centre>DEV632</cost_centre><total>1024.01</total><payment_method>personal card</expense>";

            var response = await PostToHandler("Calculate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.Equal(0m, doc.RootElement.GetProperty("SalesTaxValue").GetDecimal());
            Assert.Equal(0m, doc.RootElement.GetProperty("TotalExcludingSalesTax").GetDecimal());
        }

        [Fact]
        public async Task OnPostCalculate_MissingCostCentre_ReturnsCostCentreUnknown()
        {
            var message = "<expense><total>1024.01</total><payment_method>personal card</payment_method></expense>";

            var response = await PostToHandler("Calculate", message);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var doc = await ParseJsonResponse(response);
            Assert.Equal("UNKNOWN", doc.RootElement.GetProperty("CostCentreDescription").GetString());
        }

        #endregion

        private async Task<HttpResponseMessage> PostToHandler(string handler, string message)
        {
            var json = JsonSerializer.Serialize(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _webClient.PostAsync($"/?handler={handler}", content);
        }

        private static async Task<JsonDocument> ParseJsonResponse(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(content);
        }

        public class IntegrationTestFixture : IDisposable
        {
            private readonly WebApplicationFactory<MessageController> _apiFactory;
            private readonly WebApplicationFactory<IndexModel> _webFactory;

            public HttpClient WebClient { get; }

            public IntegrationTestFixture()
            {
                _apiFactory = new WebApplicationFactory<MessageController>();

                _webFactory = new WebApplicationFactory<IndexModel>()
                    .WithWebHostBuilder(builder =>
                    {
                        builder.ConfigureServices(services =>
                        {
                            services.AddHttpClient("API", client =>
                            {
                                client.BaseAddress = _apiFactory.Server.BaseAddress;
                            })
                            .ConfigurePrimaryHttpMessageHandler(() => _apiFactory.Server.CreateHandler());
                        });
                    });

                WebClient = _webFactory.CreateClient();
            }

            public void Dispose()
            {
                WebClient.Dispose();
                _webFactory.Dispose();
                _apiFactory.Dispose();
            }
        }
    }
}
