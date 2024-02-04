namespace Lesson7;

internal class Program
{
    protected Program() { }

    static void Main(string[] args)
    {
        if (args is null || args.Length != 2)
        {
            Console.WriteLine("You enter wrong arguments!");
            return;
        }

#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
        foreach (var item in args)
        {
            if (string.IsNullOrEmpty(item))
            {
                Console.WriteLine("You enter wrong arguments!");
                return;
            }
        }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions

        string ext = args[0];
        string text = args[1];
        string path = Directory.GetCurrentDirectory();

        Test test = new();

        foreach (var item in test.FindFilesByExtensionAndText(ext, path, text))
        {
            Console.WriteLine(item);
        }
    }
}
