namespace PostData
{
    public interface IHttpClientComponent
    {
        bool SetCookies(Dictionary<string, string> cookiesData, string url);
        Task<string> PostAsync(string relativeUrl, HttpContent content);
        Task<string> GetAsync(string relativeUrl);
    }
}
