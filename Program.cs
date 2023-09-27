using HwCreateGame.EasyLINQ;
using HwCreateGame.HardTask;
using HwCreateGame.StringLINQ;

class Program
{
    public static string[] firstNames = { "Alice", "Bob", "Charlie", "David", "Emma", "Frank", "Grace", "Hannah", "Isaac", "Jack" };
    static string[] lastNames = { "Smith", "Johnson", "Brown", "Lee", "Garcia", "Davis", "Martinez", "Wilson", "Anderson", "Taylor" };
    static void Main()
    {
        int min = -100;
        int max = 100;
        int[] numbers = GenerateRandomArray(min, max);

        string[] words = { "Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled", "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you" };

        // Задача 1: Найти числа, которые делятся на 2 и 3
        var task1 = new Divide2and3(numbers);
        task1.Execute();

        // Задача 2: Найти сумму всех чисел
        var task2 = new SumNumbers(numbers);
        task2.Execute();

        // Задача 3: Найти среднее значение всех чисел
        var task3 = new CalcAvNumb(numbers);
        task3.Execute();

        // Задача 4: Найти максимальное число
        var task4 = new FindMax(numbers);
        task4.Execute();

        // Задача 5: Найти минимальное число
        var task5 = new FindMin(numbers);
        task5.Execute();

        // Задача 6: Найти числа больше 10 и умножить на 10
        var task6 = new Multiply10(numbers);
        task6.Execute();

        // Задача 7: Сгруппировать числа в четные и нечетные группы и найти максимум
        var task7 = new EvenOddMax(numbers);
        task7.Execute();

        // Задача 8: Найти элементы больше среднего значения списка
        var task8 = new MoreThanAv(numbers);
        task8.Execute();

        // Задача 9: Найти уникальные символы в заданной строке
        var task9 = new UniqueChar(words);
        task9.Execute();

        // Задача 10: Группировать элементы списка строк по длине строки
        var task10 = new GroupByLength(words);
        task10.Execute();

        // Задача 11: Найти элементы списка строк, содержащие заданную подстроку и нормализовать
        var targetSubstring = "tion";
        var task11 = new FindAndNormal(words, targetSubstring);
        task11.Execute();


        // HardTask

        int numberOfUsers = 20;
        List<User> users = UserGenerator.GenerateUsers(numberOfUsers);
        var userTasks = new UserTasks(users);
      


        // Задача 2.1: Найти всех пользователей старше 18 лет 
        userTasks.FindUsersOlderThan18();

        // Задача 2.2: Группировать пользователей по домену электронной почты
        userTasks.GroupUsersByEmailDomain();

        // Задача 2.3: Преобразовать данную коллекцию в коллекцию, оптимизированную для поиска
        userTasks.OptimizeForSearch();

        // Задача 2.4: Группировать пользователей по фамилии и найти возможных родственников
        userTasks.GroupUsersByLastNameAndRelatives();
    }

    private static int[] GenerateRandomArray(int min, int max, int length = 20)
    {
        Random random = new Random();
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = random.Next(min, max + 1);
        }
        return numbers;
    }
}