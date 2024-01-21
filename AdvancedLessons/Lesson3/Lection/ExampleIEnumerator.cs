using System.Collections;

namespace Lesson3;
internal class ExampleIEnumerator
{
    public static void Run(string[] args)
    {
        var list = new ArrayList() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        IEnumerator enumerator = list.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
}
