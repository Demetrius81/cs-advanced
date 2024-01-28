using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class ExampleIComparer
{
    public static void Run(string[] args)
    {
        IComparer<int> comparer = new CustomIntComparer();

        int[] arr = new int[] { 0, 9, 9, 7, 1, 2, 3, 4, 5, 3, 6, 7, 1 };

        Array.Sort(arr);

        PrintArray(arr);

        Array.Sort(arr, comparer);

        PrintArray(arr);

    }

    private static void PrintArray(int[] arr) 
    {
        foreach (var i in arr)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
    }
}
