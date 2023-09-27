using System;

public class EmailEventArgs : EventArgs
{
    public string Subject { get; set; }
    public string Body { get; set; }
}