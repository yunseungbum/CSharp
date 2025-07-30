
public class DaumInfoJson
{
    public string id { get; set; }
    public string uid { get; set; }
    public string folderId { get; set; }
    public List<string> labelIds { get; set; }
    public int size { get; set; }
    public List<object> attachedMails { get; set; }
    public List<object> attachments { get; set; }
    public List<MailAddress> bccList { get; set; }
    public List<MailAddress> ccList { get; set; }
    public string contents { get; set; }
    public MailAddress from { get; set; }
    public List<Header> headers { get; set; }
    public bool isForged { get; set; }
    public bool isPretend { get; set; }
    public string originCode { get; set; }
    public string recvTime { get; set; }
    public List<MailAddress> replyToList { get; set; }
    public string sendTime { get; set; }
    public string subject { get; set; }
    public MailAddress to { get; set; }
    public List<MailAddress> toList { get; set; }
}

public class MailAddress
{
    public string name { get; set; }
    public string addr { get; set; }
}

public class Header
{
    public string name { get; set; }
    public string value { get; set; }
}


