using System;

public class Mailbox
{
    public event EventHandler<EmailEventArgs> NewMailArrived;

    public void AddMail(string subject, string body)
    {
        var emailArgs = new EmailEventArgs { Subject = subject, Body = body };
        OnNewMailArrived(emailArgs);
    }

    protected virtual void OnNewMailArrived(EmailEventArgs e)
    {
        NewMailArrived?.Invoke(this, e);
    }
}