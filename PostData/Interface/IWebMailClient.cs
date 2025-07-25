namespace PostData
{
    internal interface IWebMailClient
    {
        Task FetchMailAsync(string mailSN);
    }
}
