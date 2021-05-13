using FacebookSignInApi.Services.Facebook.Responses.DebugToken;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FacebookSignInApi.Services
{
    public class FacebookService : IFacebookService
    {
        private HttpClient _httpClient;

        public FacebookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DebugTokenResponse> DebugToken(string inputToken, string accessToken)
        {
            var url = "https://graph.facebook.com/debug_token?input_token=" + inputToken + "&access_token=" + accessToken;
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            httpResponse.EnsureSuccessStatusCode();
            string json = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<DebugTokenResponse>(json);
            return response;
        }
    }
}
