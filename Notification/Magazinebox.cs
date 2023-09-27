using System;

public class Magazinebox
{
    public event EventHandler<MagazineArgs> NewMagazineArrived;

    public void AddMagazine(string subject, string body)
    {
        var magazineArgs = new MagazineArgs { Subject = subject, Body = body };
        OnNewMagazineArrived(magazineArgs);
    }

    protected virtual void OnNewMagazineArrived(MagazineArgs e)
    {
        NewMagazineArrived?.Invoke(this, e);
    }
}