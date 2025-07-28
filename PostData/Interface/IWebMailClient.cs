namespace PostData
{
    internal interface IWebMailClient
    {
        Task<bool> FetchMailAsync(string mailSN);
    }
}
