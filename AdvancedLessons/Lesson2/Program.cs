namespace Lesson2;

internal class Program
{
    protected Program()
    {

    }

    static void Main(string[] args)
    {
        byte byteNum = 243;
        short shortNum = 3873;
        int intNum = 45684;
        long longNum = 55548484;

        Console.WriteLine(byteNum);
        Console.WriteLine(shortNum);
        Console.WriteLine(intNum);
        Console.WriteLine(longNum);
        Console.WriteLine();

        Bits b1 = (Bits)byteNum;
        Bits b2 = (Bits)shortNum;
        Bits b3 = (Bits)intNum;
        Bits b4 = (Bits)longNum;

        Console.WriteLine($"{b1.GetType()} : {b1.ToString()}");
        Console.WriteLine($"{b2.GetType()} : {b2.ToString()}");
        Console.WriteLine($"{b3.GetType()} : {b3.ToString()}");
        Console.WriteLine($"{b3.GetType()} : {b4.ToString()}");
        Console.WriteLine();

        byte resultByte = b1;
        short resultShort = b2;
        int resultInt = b3;
        long resultLong = b4;

        Console.WriteLine($"{resultByte.GetType()} : {resultByte.ToString()}");
        Console.WriteLine($"{resultShort.GetType()} : {resultShort.ToString()}");
        Console.WriteLine($"{resultInt.GetType()} : {resultInt.ToString()}");
        Console.WriteLine($"{resultLong.GetType()} : {resultLong.ToString()}");
        Console.WriteLine();
    }
}
