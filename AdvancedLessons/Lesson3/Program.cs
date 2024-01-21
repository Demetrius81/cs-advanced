namespace Lesson3;

internal class Program
{
    static void Main(string[] args)
    {
        var arr = new int[,,] {
            { { 1,0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } },
            { { 1, 0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } },
            { { 1, 0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } }
        };

        var result1 = Labyrinth.HasExit(1, 1, 1, arr);
        Console.WriteLine("Just count of exits");
        Console.WriteLine(result1);

        var point = new Point(1, 1, 1);

        var result2 = Labyrinth.HasExitPromoutedHW(point, arr);
        Console.WriteLine("Count of exits and coordinates exit points");
        Console.WriteLine(result2.exitsCount);

        foreach (var item in result2.coordinates)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
