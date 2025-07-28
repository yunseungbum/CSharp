namespace PostData
{
    public partial class NaverMailService
    {
        public Dictionary<string, string> CreateReadMailRequest(string mailSN)
        {
            return new Dictionary<string, string>
            {
                { "mailSN", mailSN },
                { "folderSN", "0" },
                { "previewMode", "1" },
                { "prevNextMail", "true" },
                { "threadMail", "true" },
                { "folderName", "" },
                { "charset", "" },
                { "viewAll", "false" },
                { "markRead", "true" }
            };
        }
    }
}
