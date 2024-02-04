using System.Reflection;
using System.Text;

namespace Lesson6;

internal class HomeWork
{
    internal void Run(string[] args)
    {
        Type type = typeof(TestClass);

        //var t1 = Activator.CreateInstance(type);
        //var t2 = Activator.CreateInstance(type, new Object[] { 1 });
        //var t3 = Activator.CreateInstance(type, new Object[] { 1, "строка", 2.0, new char[] { 'A', 'B', 'C' } });

        var s = ObjectToString(new TestClass(15, "STR", 2.2m, new char[] { 'A', 'B', 'C' }));
        Console.WriteLine(s);
        //var o = StringToObject(s) as TestClass;

        //Console.WriteLine(o.GetType());

    }


    static string ObjectToString(object obj)
    {
        StringBuilder sb = new();
        Type type = obj.GetType();
        sb.Append(type.Assembly.FullName + ":");
        sb.Append(type.Name + "|");
        List<PropertyInfo> properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        properties.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
        foreach (var prop in properties)
        {
            Console.WriteLine(prop.Name);
            var value = prop.GetValue(obj);
            //var attr = prop.GetCustomAttribute<CustomNameAttribute>();
            sb.Append((/*attr?.Name ?? */prop.Name) + ":");
            if (prop.PropertyType == typeof(char[]))
            {
                sb.Append(new String(value as char[]) + "|");
            }
            else
                sb.Append(value + "|");
        }

        return sb.ToString();

    }

    static object StringToObject(string s)
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine(s);
        Console.WriteLine("-------------------------------------------------------------");
        var values = s.Split("|").ToList();
        values.Remove("");

        var classAssemblyAndName = values[0].Split(':');

        //var obj = Activator.CreateInstance(typeof(TestClass));
        var obj = Activator.CreateInstance(classAssemblyAndName[0],/*"Lesson6.TestClass"*/ classAssemblyAndName[1])?.Unwrap();

        if (values.Count > 1 && obj is not null)
        {
            var type = obj.GetType();
            Console.WriteLine(type);

            

            for (int i = 1; i < values.Count; i++)
            {
                var nameAndValue = values[i].Split(':');

                var pi = type.GetProperty(nameAndValue[0]);

                Console.WriteLine($"{nameAndValue[0]}:{nameAndValue[1]}");

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

