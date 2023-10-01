using HwCreateGame.HwCreateGame;
using HwCreateGame;

class Program
{
    static void Main(string[] args)
    {
        var binaryTree = new BinaryTree<int>();

        Console.WriteLine("Введите числа для добавления в бинарное дерево (для завершения введите 'q'):");

        while (true)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "q")
                break;

            if (int.TryParse(input, out int number))
            {
                binaryTree.Insert(number);
            }
            else
            {
                Console.WriteLine("Некорректный ввод числа. Попробуйте еще раз.");
            }
        }

        Console.WriteLine("Бинарное дерево:");
        binaryTree.PrintTree();

        Console.WriteLine("Прямой обход дерева:");
        Traversal<int> traversal = new Traversal<int>();
        traversal.PreOrderTraversal(binaryTree.RootNode);

        Console.WriteLine("\nСпиральный обход дерева:");
        traversal.SpiralTraversal(binaryTree.RootNode);

        Console.WriteLine("\nВведите число для поиска в дереве:");
        string searchInput = Console.ReadLine();

        if (int.TryParse(searchInput, out int searchNumber))
        {
            BinarySearch<int> binarySearch = new BinarySearch<int>();
            bool found = binarySearch.Search(binaryTree.RootNode, searchNumber);

            if (found)
            {
                Console.WriteLine("Элемент найден в дереве.");
            }
            else
            {
                Console.WriteLine("Элемент не найден в дереве.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод числа для поиска. Попробуйте еще раз.");
        }

        Console.ReadLine();
    }
}
