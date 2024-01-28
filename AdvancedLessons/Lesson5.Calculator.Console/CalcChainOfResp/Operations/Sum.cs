using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal sealed class Sum : Operation
{
    public Sum(
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
        if (operation == ConsoleKey.Add || operation == ConsoleKey.OemPlus)
        {
            return Function.Invoke(Calc.Sum, null, null);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
