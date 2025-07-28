public class Root
{
    public string Result { get; set; }
    public string Message { get; set; }
    public string LoginStatus { get; set; }
    public NextMailData nextMailData { get; set; }
    public MailInfo mailInfo { get; set; }
    public ReactionInfo reactionInfo { get; set; }
}

public class NextMailData
{
    public string subject { get; set; }
    public From from { get; set; }
}

public class From
{
    public string name { get; set; }
    public string email { get; set; }
}


public class ReactionInfo
{
    public bool reactionMail { get; set; }
}

public class AttachList
{
    public int attachCount { get; set; }
    public string attachsizeAll { get; set; }
}

public class MailInfo
{
    public string subject { get; set; }
    public string body { get; set; }
}

public class PrevMailData
{
    public string subject { get; set; }
    public From from { get; set; }
}
