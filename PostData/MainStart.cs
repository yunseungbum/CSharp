namespace PostData
{
    public class MainStart
    {
        static async Task Main(string[] args)
        {
            await new MailService().StartAsync();
        }
    }
}
