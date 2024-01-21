using System.Collections;

namespace Lesson3;
internal class ExampleBitArray
{
    private static void PrintBitArray(BitArray bits)
    {
        foreach (bool bit in bits)
        {
            Console.Write(bit ? "1 " : "0 ");
        }
        Console.WriteLine();
    }
    public static void Run(string[] args)
    {
        var bits = new BitArray(8, false);

        bits.Or(new BitArray(new bool[] {true, false, false, false, false, false, false, false }));

        PrintBitArray(bits);

        bits.Xor(new BitArray(new bool[] { true, true, false, false, false, false, false, false }));

        PrintBitArray(bits);

        bits.And(new BitArray(new bool[] { true, false, false, false, false, false, false, false }));

        PrintBitArray(bits);

        bits.Not();

        PrintBitArray(bits);
    }
}
