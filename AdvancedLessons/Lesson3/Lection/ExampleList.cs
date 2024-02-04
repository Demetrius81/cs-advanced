using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class ExampleList
{
    public static void Run(string[] args)
    {
        var l1 = new List<int>(20);

        for (int i = 0; i < 20; i++)
        {
            l1.Add(i + 1);
        }

        Console.WriteLine(l1[19]);
        int index = l1.BinarySearch(8); // O(Lod(N)) Sorted only!!!
        Console.WriteLine(index);
        bool isTrue = l1.Contains(2);
        Console.WriteLine(isTrue);
        var strings = l1.ConvertAll<string>(new Converter<int, string>(Convert.ToString));
        PrintArray(strings);
        var arr = new int[l1.Count];
        l1.CopyTo(1, arr, 2, 6); // 1-index from start copy; 2-index to copy; 6-count elements
        PrintArray(arr);
        l1.Clear();
        var ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var x = new List<int>();
        Console.WriteLine(x.Capacity);
        x.EnsureCapacity(ints.Count);
        Console.WriteLine(x.Capacity);
        var intsNew = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine(ints.Equals(intsNew));
        Console.WriteLine("-----------------------------------------------");

        var sx = new List<string>() { "AaAaA", "AAAAA", "aaa", "BBBB" };

        var result = sx.Find(IsCapital);

        Console.WriteLine(result);

        result = sx.FindLast(IsCapital);

        Console.WriteLine(result);

        var resiltCollection = sx.FindAll(IsCapital);

        PrintArray(resiltCollection);

        //index = sx.FindIndex(IsCapital);

        index = 0;

        do
        {
            index = sx.FindIndex(index, IsCapital);
            if (index >= 0)
            {
                Console.WriteLine(index);
                index++;
            }
        }
        while (index >= 0 && index < sx.Count);

        sx.ForEach(Console.WriteLine);
        sx.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        Console.WriteLine(sx.IndexOf("aaa"));

        Console.WriteLine("-----------------------------------------------");
        ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 };

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.Insert(1, 99);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.InsertRange(4, new int[] { 66, 88, 77 });

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        Console.WriteLine(ints.Remove(1000));

        Console.WriteLine(ints.Remove(99));

        while (ints.Remove(9)) ;

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.RemoveAt(3);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.RemoveRange(3, 2);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        var y = ints.RemoveAll(IsEvent);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        Console.WriteLine($"четных чисел было {y}");

        ints.Reverse();

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();
        ints.Reverse();


        ints.Reverse(1, 2);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.Sort();

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.Sort(CompareInt);

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        ints.Sort();
        ints.Reverse();

        ints.ForEach(x => Console.Write(x + " "));
        Console.WriteLine();

        var res = ints.TrueForAll(x => !IsEvent(x));

        Console.WriteLine(res);

        //foreach (var item in ints)
        //{
        //    Console.WriteLine(item);
        //    ints.Clear(); // Exsception
        //}

    }

    static int CompareInt(int x, int y)
    {
        return x.CompareTo(y) * -1;
    }

    private static bool IsEvent(int i)
    {
        return i % 2 == 0;
    }

    private static bool IsCapital(string s)
    {
        foreach (var c in s)
        {
            if (!Char.IsUpper(c))
            {
                return false;
            }
        }

        return true;
    }

    private static void PrintArray<T>(IEnumerable<T> arr)
    {
        foreach (var i in arr)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
    }
}
