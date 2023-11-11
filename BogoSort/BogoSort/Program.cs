using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7, -10  };
        Console.WriteLine("Array non ordinato:");
        PrintArray(arr);
        Console.WriteLine("[0] bogosort");
        Console.WriteLine("[1] mergesort");
        string risposta;
        risposta = Console.ReadLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        if (risposta == "0")
        {
            Console.WriteLine("BOGO (POTREBBE VOLERCI UN PO')");
            BogoSort(arr);
        }
        else
        {
            Console.WriteLine("MERGE");
            MergeSort(arr, 0, arr.Length - 1);
        }
        stopwatch.Stop();
        Console.WriteLine("\nArray ordinato:");
        PrintArray(arr);

        Console.WriteLine($"Tempo di esecuzione: {stopwatch.Elapsed.TotalMilliseconds} millisecondi");

        Console.ReadLine();
    }

    static void BogoSort(int[] arr)
    {
        while (!IsSorted(arr))
        {
            Shuffle(arr);
        }
    }

    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static void Shuffle(int[] arr)
    {
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            int j = random.Next(i, arr.Length);
            Swap(arr, i, j);
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    static void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] L = new int[n1]; //sinistra
        int[] R = new int[n2]; //destra

        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[middle + 1 + j];

        int k = left;
        int x = 0, y = 0;

        while (x < n1 && y < n2)
        {
            if (L[x] <= R[y])
            {
                arr[k] = L[x];
                x++;
            }
            else
            {
                arr[k] = R[y];
                y++;
            }
            k++;
        }

        while (x < n1)
        {
            arr[k] = L[x];
            x++;
            k++;
        }

        while (y < n2)
        {
            arr[k] = R[y];
            y++;
            k++;
        }
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }
}
