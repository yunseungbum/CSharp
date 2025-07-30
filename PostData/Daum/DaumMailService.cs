using Newtonsoft.Json;

namespace PostData
{
    
    public partial class DaumMailService : IWebMailClient
    {
        private readonly IHttpClientComponent httpComponent;
        public DaumMailService()
        {
            httpComponent = new HttpClientComponent();
            InitializeCookies();   
        }
        private void InitializeCookies()
        {
            _T_ANO = "your_T_ANO";
            HTS = "your_HTS";
            ALID = "your_ALID";
            LSID = "your_LSID";
            PROF = "your_PROF";
            ENAI = "your_ENAI";
            HM_CU = "your_HM_CU";
            TS = "your_TS";
        }

        public async Task<bool> FetchMailAsync(string mailSN)
        {
            DaumSetCookies();
            string url = $"https://cmail.daum.net/v2/mails/{mailSN}?headerFields=Date&includeVIPLabel=true";
            string result = await httpComponent.GetAsync(url);
            return DaumProcessResponse(result);
        }
        private void DaumSetCookies()
        {
            string baseUri = "https://cmail.daum.net";

            var cookieDict = new Dictionary<string, string>
            {
                { "_T_ANO", _T_ANO },
                { "HTS", HTS },
                { "ALID", ALID },
                { "LSID", LSID },
                { "ENAI", ENAI },
                { "PROF", PROF },
                { "DMS", DMS },
                { "HM_CU", HM_CU },
                { "TS", TS }
            };

            httpComponent.SetCookies(cookieDict, baseUri);
        }

        private bool DaumProcessResponse(string result)
        {
            try
            {
                DaumInfoJson root = JsonConvert.DeserializeObject<DaumInfoJson>(result);

                if (root.id == "FAIL")
                {
                    Console.WriteLine("로그인이 필요합니다.");
                    return false;
                }

                if (root?.subject != null)
                {
                    Console.WriteLine($"제목: {root.subject}");
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
