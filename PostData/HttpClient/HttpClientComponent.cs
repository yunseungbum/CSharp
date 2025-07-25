using System.Net;

namespace PostData
{
    public class HttpClientComponent: IHttpClientComponent
    {
        private HttpClientHandler HttpClientHandler { get; set; }
        public HttpClient HttpClient { get; private set; }

        public HttpClientComponent()
        {
            InitalizeSetting();

            HttpClient = new HttpClient(HttpClientHandler);
        }

        private void InitalizeSetting()
        {
            HttpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseCookies = true,
                CookieContainer = new CookieContainer(),
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
        }

        public bool SetCookies(Dictionary<string, string> cookiesData, string url)
        {
            try
            {
                foreach (var cookie in cookiesData)
                {
                    HttpClientHandler.CookieContainer.Add(new Uri(url), new Cookie(cookie.Key, cookie.Value));
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<string> PostAsync(string relativeUrl, HttpContent content)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsync(relativeUrl, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

