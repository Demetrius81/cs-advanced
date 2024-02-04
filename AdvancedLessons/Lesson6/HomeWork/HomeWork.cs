using System.Reflection;
using System.Text;

namespace Lesson6;

internal class HomeWork
{
    internal void Run(string[] args)
    {
        string str = ObjectToString(new TestClass(15, "STR", 2.2m, new char[] { 'A', 'B', 'C' }));

        Console.WriteLine("Экземпляр класса преобразован в строку:");
        Console.WriteLine(str);

        TestClass? obj = StringToObject(str) as TestClass;

        Console.WriteLine("Строка преобразована в экземпляр класса:");
        Console.WriteLine(obj?.GetType());
    }


    static string ObjectToString(object obj)
    {
        StringBuilder sb = new();
        Type type = obj.GetType();
        sb.Append(type.Assembly.FullName + ":");
        sb.Append(type.Name + "|");
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        List<PropertyInfo> properties = [.. type.GetProperties(bindingAttr: BindingFlags.NonPublic
                                                                            | BindingFlags.Instance)];
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        properties.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj);
            var attr = prop.GetCustomAttribute<CustomNameAttribute>();
            sb.Append((attr?.Name ?? prop.Name) + ":");
            if (prop.PropertyType == typeof(char[]))
            {
                sb.Append(new String(value as char[]) + "|");
            }
            else
            {
                sb.Append(value + "|");
            }
        }

        return sb.ToString();
    }

    static object? StringToObject(string s)
    {
        var values = s.Split("|").ToList();
        values.Remove("");

        var classAssemblyAndName = values[0].Split(':');

        var obj = Activator.CreateInstance(classAssemblyAndName[0], $"{classAssemblyAndName[0].Split(',')[0]}.{classAssemblyAndName[1]}")?.Unwrap();

        if (values.Count > 1 && obj is not null)
        {
            var type = obj.GetType();

            for (int i = 1; i < values.Count; i++)
            {
                var nameAndValue = values[i].Split(':');

                var pi = type.GetProperty(nameAndValue[0]);

                if (pi == null)
                    continue;

                if (pi.PropertyType == typeof(int))
                {
                    pi.SetValue(obj, int.Parse(nameAndValue[1]));
                }
                if (pi.PropertyType == typeof(string))
                {
                    pi.SetValue(obj, nameAndValue[1]);
                }
                if (pi.PropertyType == typeof(decimal))
                {
                    pi.SetValue(obj, decimal.Parse(nameAndValue[1]));
                }
                if (pi.PropertyType == typeof(char[]))
                {
                    pi.SetValue(obj, nameAndValue[1].ToCharArray());
                }

            }
        }
        return obj;
    }

}
