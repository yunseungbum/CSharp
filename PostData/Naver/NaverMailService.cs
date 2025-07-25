using Newtonsoft.Json.Linq;

namespace PostData
{
    public partial class NaverMailService : IWebMailClient
    {
        private readonly IHttpClientComponent httpComponent;
        private  NaverCookies Cookies;

        private readonly int MailSNNum = 8784;


        public NaverMailService()
        {
             httpComponent = new HttpClientComponent();
            InitializeCookies();
        }

        private void InitializeCookies()
        {
            Cookies = new NaverCookies
            {
                NidSes = "Your NidSes",
                NidAut = "Your NidAut"
            };
        }

        public async Task FetchMailAsync(string mailSN)
        {
            NaverSetCookies();

            FormUrlEncodedContent content = NaverRequestContent(mailSN);

            string result = await httpComponent.PostAsync("https://mail.naver.com/json/read", content);

            NaverProcessResponse(result);
        }

        private void NaverSetCookies()
        {
            string baseUri = "https://mail.naver.com";

            var cookieDict = new Dictionary<string, string>
            {
                { "NID_SES", Cookies.NidSes },
                { "NID_AUT", Cookies.NidAut }
            };

            httpComponent.SetCookies(cookieDict, baseUri);
        }

        private FormUrlEncodedContent NaverRequestContent(string mailSN)
        {
            MailRequestDictionary mailRequestDictionary = new MailRequestDictionary();
            Dictionary<string, string> values = mailRequestDictionary.CreateReadMailRequest(mailSN);
            return new FormUrlEncodedContent(values);
        }

        private void NaverProcessResponse(string result)
        {
            if (result.Contains("FAIL"))
            {
                Console.WriteLine(result);
                Environment.Exit(1);
            }

            JObject json = JObject.Parse(result);

            if (json.TryGetValue("mailInfo", out JToken mailInfo))
            {
                if (mailInfo["subject"] != null)
                {
                    Console.WriteLine($"제목: {mailInfo["subject"]}");
                }
                else
                {
                    Console.WriteLine("오류: subject 없음");
                }
            }
            else
            {
                Console.WriteLine("오류: 메일 정보 없음");
            }
        }

    }
}