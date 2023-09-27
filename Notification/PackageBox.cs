using HwCreateGame.Events;
using System;

public class PackageBox
{
    public event EventHandler<PackageArgs> NewPackageArrived;

    public void AddPackage(string description, string contents)
    {
        var packageArgs = new PackageArgs { Description = description, Contents = contents };
        OnNewPackageArrived(packageArgs);
    }

    protected virtual void OnNewPackageArrived(PackageArgs e)
    {
        NewPackageArrived?.Invoke(this, e);
    }
}