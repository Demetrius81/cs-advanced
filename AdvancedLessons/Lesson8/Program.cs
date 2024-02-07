using System.Runtime.CompilerServices;

namespace Lesson8;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("You enter wrong number of arguments");
            return;
        }

        if (args[0].Split('.')[1] != "json")
        {
            Console.WriteLine("This is not .json file.");
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine($"File {args[0]} not exist.");
            return;
        }

        var converter = new JsonToXmlConverter();
        converter.Convert(args[0]);
        //converter.EasyConvert(args[0]);
    }
}
