using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class ErrorMessage : Operation
{
    public ErrorMessage(Operation operation,
        ICalc calc,
        Func<Action<double>?, Action?, Func<bool>?, bool> func,
        Func<bool> quit,
        Func<bool> error)
        : base(operation, calc, func, quit, error)
    {
    }

    public override bool? Execute(ConsoleKey operation)
    {
        if (operation != ConsoleKey.F24)
        {
            return Function.Invoke(null, null, Error);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }

    }
}
