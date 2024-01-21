using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Lections;
delegate void MyDelegate();
internal static class Part1
{
    public static void SayHello()
    {
        Console.WriteLine("Привет, я - делегат!");
    }

    public static void SayBye()
    {
        Console.WriteLine("Пока!");
    }

    public static void Run(string[] args)
    {
        MyDelegate myDelegate = new MyDelegate(SayHello);
        MyDelegate myDelegate2 = SayHello;

        myDelegate();
        myDelegate2();

        Console.WriteLine("------------------------------------------------");

        myDelegate += SayBye;
        myDelegate();

        Console.WriteLine("------------------------------------------------");

        myDelegate = SayHello;
        myDelegate += SayHello;
        myDelegate += SayHello;
        myDelegate2 = SayBye;
        myDelegate += myDelegate2;
        myDelegate();

        Console.WriteLine("------------------------------------------------");

        Console.WriteLine($"В списке вызовов делегата число методов = {myDelegate.GetInvocationList().Length}");

        foreach (MyDelegate del in myDelegate.GetInvocationList())
        {
            Console.WriteLine($"Вызываем метод: {del.Method}");
            del();
        }
    }
}
