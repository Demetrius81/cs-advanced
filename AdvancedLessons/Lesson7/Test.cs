namespace Lesson7;

internal class Test
{
    private List<string> List { get; set; } = [];

    public List<string> FindFilesByExtensionAndText(string fileExt, string path, string text)
    {
        List.Clear();
        FindFileFullPath(fileExt, path, text);
        return List;
    }

    private void FindFileFullPath(string fileExt, string path, string text)
    {
        foreach (var name in Directory.GetFiles(path))
        {
            var nameExtArr = Path.GetFileName(name).Split(".");

            if (nameExtArr.Length == 2 && nameExtArr[1] == fileExt)
            {
                var temp = Path.GetFullPath(name);
                if (FileContains(temp, text))
                {
                    List.Add(temp);
                }
            }
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            FindFileFullPath(fileExt, dir, text);
        }
    }

    private bool FileContains(string path, string text)
    {
        using (StreamReader sr = new(path))
        {
#pragma warning disable S2589 // Boolean expressions should not be gratuitous
            if (sr is not null)
            {
                while (!sr.EndOfStream)
                {
                    var temp = sr.ReadLine();
                    if (temp is not null && temp.Contains(text))
                    {
                        return true;
                    }
                }
            }
#pragma warning restore S2589 // Boolean expressions should not be gratuitous
            return false;
        }
    }
}
