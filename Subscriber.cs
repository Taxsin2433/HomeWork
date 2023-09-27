using HwCreateGame.Events;
using System;

public class Subscriber
{
    private int subscriberNumber; 

    public Subscriber(int number)
    {
        subscriberNumber = number;
    }

    public void SubscribeToEmail(Mailbox mailbox)
    {
        mailbox.NewMailArrived += (sender, e) => HandleNewEmail(sender, e, subscriberNumber);
    }

    public void SubscribeToMagazine(Magazinebox magazinebox)
    {
        magazinebox.NewMagazineArrived += (sender, e) => HandleNewMagazine(sender, e, subscriberNumber);
    }

    public void SubscribeToPackage(PackageBox packageBox)
    {
        packageBox.NewPackageArrived += (sender, e) => HandleNewPackage(sender, e, subscriberNumber);
    }

    public void HandleNewEmail(object sender, EmailEventArgs e, int subscriberNumber)
    {
        OutputBuffer.Add($"{subscriberNumber} подписчик - Почта: Тема - {e.Subject}, Текст - {e.Body}");
    }

    public void HandleNewMagazine(object sender, MagazineArgs e, int subscriberNumber)
    {
        OutputBuffer.Add($"{subscriberNumber} подписчик - Журнал: Тема - {e.Subject}, Текст - {e.Body}");
    }

    public void HandleNewPackage(object sender, PackageArgs e, int subscriberNumber)
    {
        OutputBuffer.Add($"{subscriberNumber} подписчик - Посылка: Описание - {e.Description}, Содержимое - {e.Contents}");
    }
}