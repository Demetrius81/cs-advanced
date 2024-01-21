namespace Lesson4;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> ints = new List<int> { 1, 2, 13, 14, 5, 46, 7, 8, 9, 10, 4, 18, 6, 45, 40};
        int target = 78;

        var result3 = FindNumbers.FindThreeNumbersLoop(ints, target);
        Console.WriteLine("Решение в лоб тремя вложенными циклами");
        Console.WriteLine($"{result3.firstNumber} + {result3.secondNumber} + {result3.thirdNumber} = {target}\r\n");

        var result = FindNumbers.FindThreeNumbersHashSet(ints, target);
        Console.WriteLine("Решение с двумя циклами и HashSet");
        Console.WriteLine($"{result.firstNumber} + {result.secondNumber} + {result.thirdNumber} = {target}\r\n");

        var result2 = FindNumbers.FindThreeNumbersWhileLoopWithTwoSholders(ints, target);
        Console.WriteLine("Решение с двумя циклами и проходом коллекции с двух сторон");
        Console.WriteLine($"{result2.firstNumber} + {result2.secondNumber} + {result2.thirdNumber} = {target}\r\n");
    }
}
