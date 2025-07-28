using Newtonsoft.Json;

namespace PostData
{
    public partial class NaverMailService : IWebMailClient
    {
        private readonly IHttpClientComponent httpComponent;

        public NaverMailService()
        {
            httpComponent = new HttpClientComponent();
            InitializeCookies();
        }

        private void InitializeCookies()
        {
            NidSes = "Your-NidSes";
            NidAut = "Your-NidAut";           
        }

        public async Task<bool> FetchMailAsync(string mailSN)
        {
            NaverSetCookies();

            string result = await httpComponent.PostAsync("https://mail.naver.com/json/read", NaverRequestContent(mailSN));

            return NaverProcessResponse(result);
        }

        private void NaverSetCookies()
        {
            string baseUri = "https://mail.naver.com";

            var cookieDict = new Dictionary<string, string>
            {
                { "NID_SES", NidSes },
                { "NID_AUT", NidAut }
            };

            httpComponent.SetCookies(cookieDict, baseUri);
        }

        private FormUrlEncodedContent NaverRequestContent(string mailSN)
        {
            Dictionary<string, string> values = CreateReadMailRequest(mailSN);
            return new FormUrlEncodedContent(values);
        }

        private bool NaverProcessResponse(string result)
        {
            try
            {
                Root root = JsonConvert.DeserializeObject<Root>(result);

                if (root.Result == "FAIL" && root.LoginStatus == "NOLOGIN")
                {
                    Console.WriteLine("로그인이 필요합니다.");
                    return false;
                }

                if (root?.mailInfo != null)
                {
                    Console.WriteLine($"제목: {root.mailInfo.subject}");
                    return true;
                }
                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"예외 발생: {ex.Message}");
                return false;
            }
        }
    }
}