using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Lections;



internal class Part2
{
    public static void SayHello(string name)
    {
        Console.WriteLine($"Привет, я - {name}!");
    }

    public static string DigitToRoman(int x)
    {
        switch (x)
        {
            case 1: return "I";
            case 2: return "II";
            case 3: return "III";
            case 4: return "IV";
            case 5: return "V";
            case 6: return "VI";
            case 7: return "VII";
            case 8: return "VIII";
            case 9: return "IX";
            case 10: return "X";
            default: return "";
        }
    }

    public static bool IsEven(int x)
    {
        return x % 2 == 0;
    }

    public static void Run(string[] args)
    {
        Action<string> action = SayHello;
        action.Invoke("Делегат");

        var list = new List<string>() { "Анна", "Александр" };

        list.ForEach(action);
        list.ForEach(new Action<string>(SayHello));

        var ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Func<int, string> func = DigitToRoman;

        var romans = ints.Select(new Func<int, string>(DigitToRoman));
        var romans2 = ints.Select(func);

        romans.ToList().ForEach((x) => Console.Write(x.PadLeft(5, ' ')));

        Console.WriteLine();

        Predicate<int> predicate = IsEven;

        
    }
}
