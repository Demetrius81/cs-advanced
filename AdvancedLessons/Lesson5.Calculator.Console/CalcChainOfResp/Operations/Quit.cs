using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class Quit : Operation
{
    public Quit(
        Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error
        ) : base(operation, calc, func, quit, error)
    {
    }

    public override bool? Execute(ConsoleKey operation)
    {
        if (operation == ConsoleKey.Escape || operation == ConsoleKey.Spacebar)
        {
            return Function.Invoke(null, null, Quit);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
