using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebView2Browser;

namespace WebViewTest
{
    public partial class MainForm : Form
    {
        /* 요구 사항
         * 1. 쇼핑몰 연결을 눌러 esm로그인을 진행
         * 1-1. 로그인 성공 후 쿠키 값을 쿠키A(richbox1)에 표시한다.
         
         * 2. HttpClient를 사용하여 패킷 로그인을 진행한다.
         * 2-1. 패킷 로그인 결과 값을 쿠키B(최근 데이터)에 표시한다.
         * 2-2. 다시 패킷 로그인 버튼을 눌러 데이터 변경 여부 확인한다.
         *      최근 데이터를 이전 데이터로 이등
                패킷 로그인 후 받은 데이터를 최근 데이터에 표시
         
         * 3. 2번에서 얻은 쿠키의 "만료 시간을 분석하고, 한국 시간 등으로 표시한다."         
         */

        private WebView2Form WebView2Form;        

        private string Cguid { get; set; }
        private string Pguid { get; set; }
        private string EsmPc { get; set; }
        private string EsmAuthPc { get; set; }
        private string EsmTOKEN { get; set; }


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    
        private async void EsmButton_Click(object sender, EventArgs e)
        {
            WebView2Form = new WebView2Form();
            WebView2Form.Show();

            await WebView2Form.InitializeWebView2();
            await WebView2Form.InitializationCompletionSource.Task;

            await EsmLoginAsync("yourId", "yourPwd", "marketName", 0000000);

            WebView2Form.WebView2.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }

        private async void PacketLoginBtn_Click(object sender, EventArgs e)
        {
            string baseUrl = "https://signin.esmplus.com";

            HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            SetCookies(handler, baseUrl);

            using (HttpClient client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                client.DefaultRequestHeaders.Referrer = new Uri($"{baseUrl}/login");
                client.DefaultRequestHeaders.Add("Origin", baseUrl);

                object payload = CreateLoginPayload();

                string responseText = await SendLoginRequestAsync(client, $"{baseUrl}/api/login", payload);

                JObject loginResultJObject = JObject.Parse(responseText);
                string encData = loginResultJObject["data"]["encData"].ToString();
                string encDataEncoded = Uri.EscapeDataString(encData);

                string nextUrl = "/Home/v2";
                string clientIp = "211.60.226.219, 172.18.0.102";

                string getTokenUrl = $"https://www.esmplus.com/Member/Authenticate/JwtAuthService?JwtToken={encDataEncoded}&NextUrl={Uri.EscapeDataString(nextUrl)}&ClientIp={Uri.EscapeDataString(clientIp)}";
        
                richTextBox3.Text = richTextBox2.Text;
                richTextBox2.Clear();
                richTextBox2.Text = await RequestTokenAsync(getTokenUrl);

                ExtractExpiresFromCookie(responseText);
              
                BeforeDataRichTextBox.Text = AfterDataRichTextBox.Text;
                AfterDataRichTextBox.Text = ExtractExpiresFromCookie(responseText);
            }
        }

        async Task<string> RequestTokenAsync(string getTokenUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(getTokenUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return $"요청 실패: {(int)response.StatusCode} {response.ReasonPhrase}";
                }

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        private async void InfoBtnClick(object sender, EventArgs e)
        {
            try
            {
                string result = await CollectOrdersFromCookiesAsync();
                InfoTextBox.Text = result;
            }
            catch (Exception ex)
            {
                InfoTextBox.Text = $"[오류] {ex.Message}";
            }
        }

     


        //logic
        private async void CoreWebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            CoreWebView2CookieManager cookieManager = WebView2Form.WebView2.CoreWebView2.CookieManager;

            List<CoreWebView2Cookie> cookies = await cookieManager.GetCookiesAsync("https://www.esmplus.com");

            StringBuilder sb = new StringBuilder();

            foreach (CoreWebView2Cookie cookie in cookies)
            {
                sb.AppendLine($"{cookie.Name} = {cookie.Value}; Domain={cookie.Domain}; Path={cookie.Path}; Expires={cookie.Expires}");

                switch (cookie.Name)
                {
                    case "CGUID":
                        Cguid = cookie.Value;
                        break;
                    case "PGUID":
                        Pguid = cookie.Value;
                        break;
                    case "ESM_PC":
                        EsmPc = cookie.Value;
                        break;
                    case "ESM_REQUEST_AUTH_PC":
                        EsmAuthPc = cookie.Value;
                        break;
                    case "ESM_TOKEN":
                        EsmTOKEN = cookie.Value;
                        break;
                }
            }
            string cookieString = sb.ToString().Trim();

            richTextBox1.Clear();
            richTextBox1.Text = cookieString;
        }

        private object CreateLoginPayload()
        {
            return new
            {
                loginId = "yourId",
                password = "yourPwd",
                rememberMe = false,
                siteType = "MarketName",
                captcha = false,
                captchaRequest = new
                {
                    input = "",
                    sessionID = "",
                    token = ""
                },
                atoCollectData = new { },
                nextUrl = ""
            };
        }

        private void SetCookies(HttpClientHandler handler, string baseUrl)
        {
            var baseUri = new Uri(baseUrl);
            handler.CookieContainer.Add(baseUri, new Cookie("CGUID", Cguid));
            handler.CookieContainer.Add(baseUri, new Cookie("PGUID", Pguid));
            handler.CookieContainer.Add(baseUri, new Cookie("ESM_PC", EsmPc));
            handler.CookieContainer.Add(baseUri, new Cookie("ESM_REQUEST_AUTH_PC", EsmAuthPc));
            handler.CookieContainer.Add(baseUri, new Cookie("ESM_TOKEN", EsmTOKEN));
        }

        private async Task<string> SendLoginRequestAsync(HttpClient client, string url, object loginPayload)
        {
            string json = JsonConvert.SerializeObject(loginPayload);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        private string ExtractExpiresFromCookie(string responseText)
        {
            if (string.IsNullOrEmpty(responseText))
                return "쿠키 정보가 없습니다.";

            int startIndex = responseText.IndexOf("Expires=");

            if (startIndex < 0)
                return "Expires 정보가 없습니다.";

            int endIndex = responseText.IndexOf(';', startIndex);

            string expiresPart;

            if (endIndex > startIndex)
                expiresPart = responseText.Substring(startIndex, endIndex - startIndex);
            else
                expiresPart = responseText.Substring(startIndex);

            return ConvertExpiresToKoreanTime(expiresPart);
        }

        private string ConvertExpiresToKoreanTime(string expiresString)
        {
            string datePart = expiresString.Replace("Expires=", "").Trim();

            string format = "ddd, dd MMM yyyy HH:mm:ss 'GMT'";

            if (DateTime.TryParseExact(datePart, format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AdjustToUniversal,
                    out DateTime parsedDate))
            {
                DateTime koreanTime = parsedDate.AddHours(9);

                return $"만료시간 = {koreanTime:yyyy}년 {koreanTime.Month}월 {koreanTime.Day}일 {koreanTime.Hour}시 {koreanTime.Minute}분 {koreanTime.Second}초";
            }
            else
            {
                return "날짜 ";
            }
        }
        private string CleanCookie(string cookieValue)
        {
            if (string.IsNullOrEmpty(cookieValue))
            {
                return "";
            }

            cookieValue = cookieValue.Replace("\r", "");
            cookieValue = cookieValue.Replace("\n", "");
            cookieValue = cookieValue.Trim();

            return cookieValue;
        }

        private async Task<string> CollectOrdersFromCookiesAsync()
        {
            var handler = new HttpClientHandler()
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            string domain = "post-tx.esmplus.com";

            handler.CookieContainer.Add(new Cookie("CGUID", CleanCookie(Cguid), "/", domain));
            handler.CookieContainer.Add(new Cookie("PGUID", CleanCookie(Pguid), "/", domain));
            handler.CookieContainer.Add(new Cookie("ESM_PC", CleanCookie(EsmPc), "/", domain));
            handler.CookieContainer.Add(new Cookie("ESM_REQUEST_AUTH_PC", CleanCookie(EsmAuthPc), "/", domain));
            handler.CookieContainer.Add(new Cookie("ESM_TOKEN", CleanCookie(EsmTOKEN), "/", domain));

            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CleanCookie(EsmTOKEN));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Referrer = new Uri("https://post-tx.esmplus.com/Home/Order");
                client.DefaultRequestHeaders.Add("Origin", "https://post-tx.esmplus.com");


                var cookies = handler.CookieContainer.GetCookies(new Uri("https://post-tx.esmplus.com"));
                StringBuilder cookieLog = new StringBuilder(">>> 전송된 쿠키:\n");
                foreach (Cookie c in cookies)
                {
                    cookieLog.AppendLine($"{c.Name} = {c.Value}; Domain={c.Domain}; Path={c.Path}");
                }
                InfoTextBox.Clear();
                InfoTextBox.AppendText(cookieLog.ToString());

                string url = "https://post-tx.esmplus.com/api/order-integration/orders?page=1&pageSize=20&tabSiteId=0&searchSDT=2025-01-01&searchEDT=2025-05-02&searchKey=ON&searchKeyword=";

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    return $"[오류] 응답 실패 {(int)response.StatusCode} {response.ReasonPhrase}\n{errorContent}";
                }

                return await response.Content.ReadAsStringAsync();
            }
        }





        #region EsmLogin
        private async Task<bool> EsmLoginAsync(string marketId, string marketPassword, string type1, int type2)
        {
            try
            {
                WebView2Form.WebView2.CoreWebView2.Navigate("https://www.esmplus.com/Home/V2");
                await LoadingAsync("esmplus");
                await DocumentPageLoadCheckAsync("h2.title.title--center");

                await Task.Delay(500);
                await WebView2Form.WebView2.ExecuteScriptAsync($"document.querySelector(\"button.uts-post.button__tab.button__tab--{type1}[data-montelena-acode='{type2}']\").click();");

                await Task.Delay(500);
                await WebView2Form.WebView2.ExecuteScriptAsync(InputDisappearLogin_ElementsByClassName(true, "form__input.form__input-xxlarge", marketId));
                await WebView2Form.WebView2.ExecuteScriptAsync(InputDisappearLogin_ElementsByClassName(false, "form__input.form__input-xxlarge", marketPassword));
                await Task.Delay(500);

                await WebView2Form.WebView2.ExecuteScriptAsync("document.querySelector(\"button.button.button--blue.button--xxlarge[data-montelena-acode='700000276']\").click();");
                await DocumentPageLoadCheckAsync("a.link__logo");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 기타
        public string InputDisappearLogin_ElementsByClassName(bool isId, string stringClass, string markerAccount)
        {
            string script = string.Empty;
            if (isId)
            {
                script = $@"
                         var input = document.querySelector('input[type=""text""].{stringClass}');
                         var nativeInputValueSetter = Object.getOwnPropertyDescriptor(window.HTMLInputElement.prototype, 'value').set;
                         nativeInputValueSetter.call(input, '{markerAccount}');
                         var ev2 = new Event('input', {{ bubbles: true }});
                         input.dispatchEvent(ev2);";
            }
            else
            {
                script = $@"
                          var input = document.querySelector('input[type=""password""].{stringClass}');
                          var nativeInputValueSetter = Object.getOwnPropertyDescriptor(window.HTMLInputElement.prototype, 'value').set;
                          nativeInputValueSetter.call(input, '{markerAccount}');
                          var ev2 = new Event('input', {{ bubbles: true }});
                          input.dispatchEvent(ev2);";

            }
            return script;
        }
        private async Task<bool> LoadingAsync(string checkUrl)
        {
            try
            {
                int tryCount = 0;
                await Task.Delay(1000);
                while (true)
                {
                    if (WebView2Form.WebView2.CoreWebView2.Source.ToString().Contains(checkUrl) == true || tryCount > 360)
                    {
                        break;
                    }
                    if (this.IsDisposed || !this.Visible)
                    {
                        break;
                    }
                    await Task.Delay(1000);
                    tryCount++;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task DocumentPageLoadCheckAsync(string html)
        {
            try
            {
                int tryCount = 0;
                while (true)
                {
                    string result = await WebView2Form.WebView2.CoreWebView2.ExecuteScriptAsync($"document.querySelector('{html}') !== null");
                    if (result == "true" || tryCount > 360)
                    {
                        break;
                    }
                    if (this.IsDisposed || !this.Visible)
                    {
                        break;
                    }
                    await Task.Delay(1000);
                    tryCount++;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
