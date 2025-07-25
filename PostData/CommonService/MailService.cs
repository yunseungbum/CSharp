namespace PostData
{
    public class MailService
    {
        int mailSNNum = 8784;

        IWebMailClient[] clients = new IWebMailClient[]
            {
                new NaverMailService()
                /*new DaumMailService(),
                new GoogleMailService()*/
            };

        public async Task StartAsync()
        {
            foreach (var client in clients)
            {
                #region 네이버
                if (client is NaverMailService)
                {
                    await MailClientLoop(client);
                }
                #endregion

                #region 다음
                /*else if(client is DaumMailService)
                {
                    mailSNNum = 33605;
                    await MailClientLoop(client);
                }*/
                #endregion
            }
        }

        private async Task MailClientLoop(IWebMailClient client)
        {
            while (true)
            {
                try
                {
                    string mailSN = mailSNNum.ToString();
                    await client.FetchMailAsync(mailSN);

                    Console.WriteLine("\n");
                    mailSNNum--;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("파일 읽기 오류: " + ex.Message);
                }

                await Task.Delay(50);
            }
        }
    }
}
