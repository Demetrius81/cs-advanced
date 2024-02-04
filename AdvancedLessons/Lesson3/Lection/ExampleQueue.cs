using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class ExampleQueue
{
    public static void Run(string[] args)
    {
        var q0 = new Queue<int>(); // Empty
        var q1 = new Queue<int>(20);
        var ints = new Queue<int>(new int[] { 8, 2, 3, 4, -1, 2, 5, 1 });

        PrintArray(ints);
        ints.Enqueue(5);
        PrintArray(ints);
        var temp = ints.Dequeue();
        PrintArray(ints);
        Console.WriteLine(temp);
        temp = ints.Peek();
        PrintArray(ints);
        Console.WriteLine(temp);

        bool isTrue = ints.TryDequeue(out int value);
        PrintArray(ints);
        Console.WriteLine(value);
        Console.WriteLine(isTrue);

        isTrue = ints.TryPeek(out value);
        PrintArray(ints);
        Console.WriteLine(value);
        Console.WriteLine(isTrue);

        while (ints.Count > 0)
        {
            if (Process(ints.Peek()))
            {
                _ = ints.Dequeue();
            }
            else
            {
                AlterProcess(ints.Dequeue());
            }
        }

        ints = new Queue<int>(new int[] { 8, 2, 3, 4, -1, 2, 5, 1 });
        Console.WriteLine("--------------------------------------------------");

        foreach (var item in DataSource())
        {
            Console.WriteLine(item);
        }

        var q = new Queue<int>();

        foreach (var item in DataSource())
        {
            q.Enqueue(item);
            if (q.Count > 5)
            {
                Console.WriteLine(q.Dequeue());
            }
        }
    }

    private static IEnumerable<int> DataSource()
    {
        for (int i = 0; i < 30; i++)
        {
            if (i < 25)
            {
                yield return i;

            }
            else
            {
                yield return i * i * i;
            }
        }
    }

    private static bool Process(int x) => x % 2 == 0;

    private static void AlterProcess(int x)
    {
        Console.WriteLine("I can not process element " + x);
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
