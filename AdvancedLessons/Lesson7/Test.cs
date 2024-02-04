using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7;
internal class Test
{
    public void Run(string[] args)
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        string path = """D:\проекты""";
#pragma warning restore S1075 // URIs should not be hardcoded
        string fileName = """index.html""";
        Console.WriteLine(FindFile(fileName, path));
    }

    public bool FindFile(string fileName, string path)
    {
        return FindFileFullPath(fileName, path) is not null;
    }

    public string? FindFileFullPath(string fileName, string path)
    {
        foreach (var name in Directory.GetFiles(path))
        {
            if (Path.GetFileName(name) == fileName)
            {
                return Path.GetFullPath(name);
            }
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            var file = FindFileFullPath(fileName, dir);

            if (file is not null)
            {
                return file;
            }
        }

        return null;
    }
}
