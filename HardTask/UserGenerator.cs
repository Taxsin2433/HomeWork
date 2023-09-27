using HwCreateGame.HardTask;

public class UserGenerator
{
    private static readonly string[] EmailDomains = { "gmail.com", "ukr.net", "outlook.com" };

    public static List<User> GenerateUsers(int numberOfUsers)

    {
        List<User> users = new List<User>();
        Random random = new Random();

        for (int i = 0; i < numberOfUsers; i++)
        {
            var user = new User
            {
                FirstName = "User" + i,
                LastName = "LastName" + i,
                Email = $"user{i}@{EmailDomains[random.Next(EmailDomains.Length)]}",
                BirthDate = DateTime.Now.AddYears(-random.Next(12, 50)),
                UserId = i
            };
            users.Add(user);
        }
        return users;
    }
}