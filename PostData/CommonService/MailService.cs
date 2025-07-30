namespace PostData
{
    public class MailService
    {
        int mailSNNum = 8784;

        IWebMailClient[] clients = new IWebMailClient[]
            {
                new NaverMailService(),
                new DaumMailService()
            };

        public async Task StartAsync()
        {
            IWebMailClient? selectedClient = null;

            while (true)
            {
                Console.Write("메일 서비스를 입력하세요 (naver/daum): ");
                string input = Console.ReadLine()?.ToLower().Trim();

                #region 네이버
                if (input == "naver")
                {
                    selectedClient = new NaverMailService();
                    await MailClientLoop(selectedClient);
                    break;
                }
                #endregion

                #region 다음
                else if (input == "daum")
                {
                    selectedClient = new DaumMailService();
                    await DaumEmailValue(selectedClient);
                    break;
                }
                #endregion
                else
                {
                    Console.WriteLine("다시 입력 해주세요.");
                }
            }

        }

        private async Task MailClientLoop(IWebMailClient client)
        {
            while (true)
            {
                try
                {
                    string mailSN = mailSNNum.ToString();

                    bool isSuccess = await client.FetchMailAsync($"{mailSN}");

                    if (isSuccess == false)
                    {
                        break;
                    }

                    Console.WriteLine("\n");
                    mailSNNum--;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("파일 읽기 오류: " + ex.Message);
                    break;
                }

                await Task.Delay(50);
            }
        }

        private async Task DaumEmailValue(IWebMailClient client)
        {
            const string prefix = "0000000000000G";
            const string chars = "abcdefghijklmnopqrstuvwxyz";

            foreach (char c1 in chars)
            {

                string mailSN = prefix + c1;

                try
                {
                    bool isSuccess = await client.FetchMailAsync(mailSN);
                    Console.WriteLine("\n");
                    if (isSuccess == false)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                await Task.Delay(50);

            }
        }
    }
}
