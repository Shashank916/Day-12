//using System;
//using System.Diagnostics;

//class QuickSortComparison
//{
//    static void Main()
//    {
//        int[] array20 = GenerateRandomArray(20);
//        int[] array30 = GenerateRandomArray(30);
//        int[] array50 = GenerateRandomArray(50);

//        Console.WriteLine("Unsorted array (size 20):");
//        PrintArray(array20);
//        Console.WriteLine("Sorted array:");
//        PrintArray(array20);
//        MeasureAndSort(array20);
//        Console.WriteLine("\n");

//        Console.WriteLine("Unsorted array (size 30):");
//        PrintArray(array30);
//        Console.WriteLine("Sorted array:");
//        PrintArray(array30);
//        MeasureAndSort(array30);
//        Console.WriteLine("\n");

//        Console.WriteLine("Unsorted array (size 50):");
//        PrintArray(array50);
//        Console.WriteLine("Sorted array:");
//        PrintArray(array50);
//        MeasureAndSort(array50);
//        Console.WriteLine("\n");
//    }
//    static void QuickSort(int[] arr)
//    {
//        QuickSort(arr, 0, arr.Length - 1);
//    }
//    static void QuickSort(int[] arr, int low, int high)
//    {
//        if (low < high)
//        {
//            int pivot = Partition(arr, low, high);

//            QuickSort(arr, low, pivot - 1);
//            QuickSort(arr, pivot + 1, high);
//        }
//    }
//    static int Partition(int[] arr, int low, int high)
//    {
//        int pivot = arr[high];
//        int i = low - 1;

//        for (int j = low; j < high; j++)
//        {
//            if (arr[j] < pivot)
//            {
//                i++;
//                Swap(ref arr[i], ref arr[j]);
//            }
//        }

//        Swap(ref arr[i + 1], ref arr[high]);
//        return i + 1;
//    }
//    static void Swap(ref int a, ref int b)
//    {
//        int temp = a;
//        a = b;
//        b = temp;
//    }
//    static bool IsSorted(int[] arr)
//    {
//        for (int i = 1; i < arr.Length; i++)
//        {
//            if (arr[i] < arr[i - 1])
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//    static int[] GenerateRandomArray(int size)
//    {
//        Random random = new Random();
//        int[] array = new int[size];
//        for (int i = 0; i < size; i++)
//        {
//            array[i] = random.Next(1, 1000); 
//        }
//        return array;
//    }
//    static void PrintArray(int[] arr)
//    {
//        foreach (int num in arr)
//        {
//            Console.Write(num + " ");
//        }
//        Console.WriteLine();
//    }
//    static void MeasureAndSort(int[] arr)
//    {
//        Stopwatch stopwatch = new Stopwatch();
//        stopwatch.Start();
//        QuickSort(arr);
//        stopwatch.Stop();
//        Console.WriteLine($"Time taken to sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
//    }
//}



using System;
using System.Diagnostics;

namespace QuickSort
{
    internal class Program
    {

        private static Random ran = new Random();
        public static int[] input(int size, int minval, int maxval) 
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = ran.Next(minval, maxval + 1);
            }

            return arr;
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);

        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
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

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        public static bool Check(int[] arr) 
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }


        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];
            Array.Copy(arr, left, leftArr, 0, n1);
            Array.Copy(arr, mid + 1, rightArr, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k] = leftArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArr[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArr[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArr[j];
                j++;
                k++;
            }

        }

        static void Main(string[] args)
        {
            int size = 100;
            int minval = 1;
            int maxval = 1000;
            int[] arr = input(size, minval, maxval);
            Console.WriteLine("Input for Quick Sort:");
            Print(arr);
            Stopwatch s = new Stopwatch();
            s.Start();
            QuickSort(arr);
            s.Stop();
            Console.WriteLine("After performing Quick Sort:");
            Print(arr);
            Console.WriteLine($"Array is having {arr.Length} elements it takes time {s.Elapsed.TotalMilliseconds}  milliseconds to sort the array using Quick Sort.");
            bool check = Check(arr);
            Console.Write("Given input is Sorted :\t" + check);
            Console.WriteLine("\n");

            int[] arr1 = input(size, minval, maxval);
            Console.WriteLine("Input for Merge Sort:");
            Print(arr1);
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            MergeSort(arr1);
            s1.Stop();
            Console.WriteLine("After performing Merge Sort:");
            Print(arr1);

            Console.WriteLine($"Array is having {arr1.Length} elements it takes time {s1.Elapsed.TotalMilliseconds}  milliseconds to sort the array using Merge Sort. ");
            Console.ReadKey();
        }
    }
}
