using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class CancelLast : Operation
{
    public CancelLast(
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
        if (operation == ConsoleKey.Backspace)
        {
            return Function.Invoke(null, Calc.CancelLast, null);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
