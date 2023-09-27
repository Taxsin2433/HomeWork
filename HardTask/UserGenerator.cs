using HwCreateGame.HardTask;

public class UserGenerator
{
    private static readonly string[] EmailDomains = { "gmail.com", "ukr.net", "outlook.com" };
    private static readonly string[] FirstNames = { "John", "Jane", "Michael", "Emily", "David", "Sarah" };
    private static readonly string[] LastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller" };

    private static string GetRandomFirstName()
    {
        Random random = new Random();
        return FirstNames[random.Next(FirstNames.Length)];
    }

    private static string GetRandomLastName()
    {
        Random random = new Random();
        return LastNames[random.Next(LastNames.Length)];
    }
    public static List<User> GenerateUsers(int numberOfUsers)

    {
        List<User> users = new List<User>();
        Random random = new Random();

        for (int i = 0; i < numberOfUsers; i++)
        {
            var user = new User
            {
                FirstName = GetRandomFirstName(),
                LastName = GetRandomLastName(),
                Email = $"user{i}@{EmailDomains[random.Next(EmailDomains.Length)]}",
                BirthDate = DateTime.Now.AddYears(-random.Next(12, 50)),
                UserId = i
            };
            users.Add(user);
        }
        return users;
    }
}