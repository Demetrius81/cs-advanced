using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class ExampleLinkedList
{
    public static void Run(string[] args)
    {
        var l0 = new LinkedList<int>(); // Empty
        var ints = new LinkedList<int>(new int[] { 8, 2, 3, 4, -1, 2, 5, 1 });

        PrintArray(ints);

        Console.WriteLine(ints.First);
        Console.WriteLine(ints.First?.Value);
        Console.WriteLine(ints.Last);
        Console.WriteLine(ints.Last?.Value);

        var node = ints.First;
        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Next;
        }

        PrintArray(ints);

        ints.AddAfter(ints.First, 99);

        PrintArray(ints);

        ints.AddBefore(ints.Last.Previous, 999);

        PrintArray(ints);

        ints.AddFirst(888);

        PrintArray(ints);

        ints.AddLast(6666);

        PrintArray(ints);

        ints.Remove(ints.Last.Previous.Previous.Previous);

        PrintArray(ints);

        ints.Remove(99);

        PrintArray(ints);

        ints.RemoveLast();

        PrintArray(ints);

        ints.RemoveFirst();

        PrintArray(ints);

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
