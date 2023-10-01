public class QuickSort
{
    public static void QS(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int replacementIndex = Partition(arr, left, right);
            QS(arr, left, replacementIndex - 1);
            QS(arr, replacementIndex + 1, right);
        }
    }

    public static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, right);
        return i + 1;
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
