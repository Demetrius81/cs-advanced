using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class ExampleStack
{
    public static void Run(string[] args)
    {
        var s0 = new Stack<int>(); // Empty
        var s1 = new Stack<int>(20);
        var ints = new Stack<int>(new int[] { 8, 2, 3, 4, -1, 2, 5, 1 });

        PrintArray(ints);
        Console.WriteLine(ints.Peek());
        PrintArray(ints);
        ints.Push(333);
        PrintArray(ints);
        ints.Push(444);
        PrintArray(ints);
        Console.WriteLine(ints.Pop());
        PrintArray(ints);
        Console.WriteLine(ints.Pop());
        PrintArray(ints);
        while (ints.TryPop(out int x))
        {
            Console.WriteLine(x);
        }
        ints = new Stack<int>(new int[] { 8, 2, 3, 4, -1, 2, 5, 1 });
        Console.WriteLine("---------------------------------------------------------------");
        string brakets = "(){}[]((())[[]{}])";
        Console.WriteLine(brakets);
        Console.WriteLine(ValidPernthesis(brakets));
        brakets = "(){}[]((()[[]{}])";
        Console.WriteLine(brakets);
        Console.WriteLine(ValidPernthesis(brakets));
    }

    static bool ValidPernthesis(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            if (c == '[')
            {
                stack.Push(']');
            }

            if (c == '(')
            {
                stack.Push(')');
            }

            if (c == '{')
            {
                stack.Push('}');
            }
            if ("])}".Contains(c))
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                if (stack.Pop() != c)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
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
