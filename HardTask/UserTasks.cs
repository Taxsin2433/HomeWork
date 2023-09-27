using HwCreateGame.HardTask;
using System;
//namespace HwCreateGame.Program;
public class UserTasks
{
    private List<User> users;

    public UserTasks(List<User> users)
    {
        this.users = users;
    }

    public void FindUsersOlderThan18()
    {
        var today = DateTime.Today;
        var result = users.Where(user => (today - user.BirthDate).TotalDays >= 365 * 18)
            .Select(user => new
            {
                FullName = $"{user.FirstName} {user.LastName}",
                BirthDate = user.BirthDate,
                Age = (int)((today - user.BirthDate).TotalDays / 365)
            });

        Console.WriteLine("Пользователи старше 18 лет:");
        foreach (var user in result)
        {
            
            Console.WriteLine($"Имя: {user.FullName}, Дата рождения: {user.BirthDate.ToShortDateString()}, Возраст: {user.Age} лет");
            Console.WriteLine();
        }
    }

    public void GroupUsersByEmailDomain()
    {
        var emailGroups = users.GroupBy(user => user.Email.Split('@')[1])
            .Select(group => new
            {
                Domain = group.Key,
                UserCount = group.Count()
            });

        var mostUsedDomain = emailGroups.OrderByDescending(group => group.UserCount).First();
        Console.WriteLine();
        Console.WriteLine($"Самый часто используемый домен: {mostUsedDomain.Domain}, Количество пользователей: {mostUsedDomain.UserCount}");
        Console.WriteLine();
       
    }

    public void OptimizeForSearch()
    {
        Dictionary<int, User> userDictionary = users.ToDictionary(user => user.UserId);

        Console.WriteLine();
        Console.WriteLine("Коллекция оптимизирована для поиска.");
        Console.WriteLine();
    }

    public void GroupUsersByLastNameAndRelatives()
    {
        var lastNameGroups = users.GroupBy(user => user.LastName);

        foreach (var group in lastNameGroups)
        {
            var orderedGroup = group.OrderBy(user => user.BirthDate);
            var relatives = orderedGroup.Select(user => new
            {
                FullName = $"{user.FirstName} {user.LastName}",
                BirthDate = user.BirthDate
            });

            Console.WriteLine($"Возможные родственники с фамилией '{group.Key}':");
            foreach (var relative in relatives)
            {
                Console.WriteLine($"Имя: {relative.FullName}, Дата рождения: {relative.BirthDate.ToShortDateString()}");
                Console.WriteLine();
            }
        }
    }

}


