using System;

public delegate Array ddStrategy(int[] ar);

public class Client
{
    int[] ar = new int[50000];
    ddStrategy ddob;

    public Client(ddStrategy concretStrategy)
    {
        Random r = new Random();
        for (int i = 0; i < ar.Length; i++)
            ar[i] = r.Next();
        this.ddob = concretStrategy;
    }

    public void DoSomeWork()
    {
        ddob(ar);
        Console.WriteLine();
    }
}

public class SortAlgorithms
{
    public static Array SortSelection(int[] array)
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Selection Sort");
        for (int i = 0; i < array.Length - 1; i++)
        {
            int k = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[k] > array[j]) k = j;
            if (k != i)
            {
                int temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }
        }
        Console.WriteLine("Time: " + (DateTime.Now - dt));
        return array;
    }

    public static Array SortBubble(int[] ar)
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Bubble Sort");
        for (int i = 0; i < ar.Length; i++)
        {
            for (int j = ar.Length - 1; j > i; j--)
            {
                if (ar[j] < ar[j - 1])
                {
                    int temp = ar[j];
                    ar[j] = ar[j - 1];
                    ar[j - 1] = temp;
                }
            }
        }
        Console.WriteLine("Time: " + (DateTime.Now - dt));
        return ar;
    }

    public static Array SortInsertion(int[] ar)
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Insertion Sort");
        for (int i = 1; i < ar.Length; i++)
        {
            int key = ar[i];
            int j = i - 1;
            while (j >= 0 && ar[j] > key)
            {
                ar[j + 1] = ar[j];
                j--;
            }
            ar[j + 1] = key;
        }
        Console.WriteLine("Time: " + (DateTime.Now - dt));
        return ar;
    }

    public static Array SortMerge(int[] array)
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Merge Sort");
        MergeSortRecursive(array, 0, array.Length - 1);
        Console.WriteLine("Time: " + (DateTime.Now - dt));
        return array;
    }

    private static void MergeSortRecursive(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            MergeSortRecursive(arr, left, middle);
            MergeSortRecursive(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    private static void Merge(int[] arr, int left, int middle, int right)
    {
        int[] leftArray = new int[middle - left + 1];
        int[] rightArray = new int[right - middle];

        Array.Copy(arr, left, leftArray, 0, middle - left + 1);
        Array.Copy(arr, middle + 1, rightArray, 0, right - middle);

        int i = 0, j = 0, k = left;

        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] <= rightArray[j])
                arr[k++] = leftArray[i++];
            else
                arr[k++] = rightArray[j++];
        }

        while (i < leftArray.Length)
            arr[k++] = leftArray[i++];

        while (j < rightArray.Length)
            arr[k++] = rightArray[j++];
    }

    public static Array SortShell(int[] array)
    {
        DateTime dt = DateTime.Now;
        Console.WriteLine("Shell Sort");
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    array[j] = array[j - gap];
                array[j] = temp;
            }
        }
        Console.WriteLine("Time: " + (DateTime.Now - dt));
        return array;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ddStrategy strategy;

        strategy = new ddStrategy(SortAlgorithms.SortSelection);
        new Client(strategy).DoSomeWork();

        strategy = new ddStrategy(SortAlgorithms.SortBubble);
        new Client(strategy).DoSomeWork();

        strategy = new ddStrategy(SortAlgorithms.SortInsertion);
        new Client(strategy).DoSomeWork();

        strategy = new ddStrategy(SortAlgorithms.SortMerge);
        new Client(strategy).DoSomeWork();

        strategy = new ddStrategy(SortAlgorithms.SortShell);
        new Client(strategy).DoSomeWork();

        Console.WriteLine("Done.");
        Console.ReadLine();
    }
}