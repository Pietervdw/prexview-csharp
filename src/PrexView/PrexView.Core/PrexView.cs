using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PrexView.Core
{
	public class PrexView
	{
		private readonly string _apiKey;

		public PrexView(string apiKey)
		{
			_apiKey = apiKey;
		}

		public async Task<byte[]>Transform(PrexViewFormat format,string data, string design, PrexViewOutput output)
		{
			var postContent = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("json", data ),
				new KeyValuePair<string, string>("format", format.ToString() ),
				new KeyValuePair<string, string>("design", design),
				new KeyValuePair<string, string>("output", output.ToString())
			});

			HttpResponseMessage response;
			using (HttpClient httpClient = new HttpClient())
			{
				httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);
				response = await httpClient.PostAsync("https://api.prexview.com/v1/transform", postContent);
			}
			var file = await response.Content.ReadAsByteArrayAsync();
			return file;
		}


		private HttpClient CreateHttpClient()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return httpClient;
		}

	}
}
