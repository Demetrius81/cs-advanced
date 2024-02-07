namespace Lesson8;

internal class Program
{
    static void Main(string[] args)
    {
        //if (args.Length != 1)
        //{
        //    Console.WriteLine("You enter wrong number of arguments");
        //    return;
        //}

        //if (!File.Exists(args[0]))
        //{
        //    Console.WriteLine($"File {args[0]} not exist.");
        //    return;
        //}

        string path = "D:\\проекты\\interno\\package.json";

        JsonToXmlConverter converter = new JsonToXmlConverter();
        converter.Convert(path);
    }
}
