using System;

class Program
{
    static void Main(string[] args)
    {
        var mailbox = new Mailbox();
        var magazine = new Magazinebox();
        var packageBox = new PackageBox();

        var subscribers = new Subscriber[5];

        for (int i = 0; i < 5; i++)
        {
            subscribers[i] = new Subscriber(i + 1); // Создание подписчика с номером
        }

        subscribers[0].SubscribeToEmail(mailbox);
        subscribers[1].SubscribeToMagazine(magazine);
        subscribers[2].SubscribeToPackage(packageBox);
        subscribers[3].SubscribeToEmail(mailbox);
        subscribers[3].SubscribeToPackage(packageBox);
        subscribers[4].SubscribeToMagazine(magazine);
        subscribers[4].SubscribeToPackage(packageBox);

        mailbox.AddMail("Письмо", "Привет, как дела?");
        magazine.AddMagazine("Выпуск 125", "О чем не скажут звезды");
        packageBox.AddPackage("Коробка", "Вещи");

        OutputBuffer.Flush(); // сорт вывод
        Console.ReadLine();
    }
}