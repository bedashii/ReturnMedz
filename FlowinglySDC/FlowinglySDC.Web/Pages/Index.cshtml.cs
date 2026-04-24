using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlowinglySDC.Web.Pages
{
	[IgnoreAntiforgeryToken]
	public class IndexModel : PageModel
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IConfiguration _configuration;

		public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			_httpClientFactory = httpClientFactory;
			_configuration = configuration;
		}

		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostValidateAsync([FromBody] string message)
		{
			var client = _httpClientFactory.CreateClient("API");
			var response = await client.PostAsJsonAsync("api/Message/ValidateUserMessage", message);
			var content = await response.Content.ReadAsStringAsync();

			return new ContentResult
			{
				Content = content,
				ContentType = "application/json",
				StatusCode = (int)response.StatusCode
			};
		}

		public async Task<IActionResult> OnPostCalculateAsync([FromBody] string message)
		{
			var client = _httpClientFactory.CreateClient("API");
			var response = await client.PostAsJsonAsync("api/Message/CalculateUserMessageCosts", message);
			var content = await response.Content.ReadAsStringAsync();

			return new ContentResult
			{
				Content = content,
				ContentType = "application/json",
				StatusCode = (int)response.StatusCode
			};
		}
	}
}
