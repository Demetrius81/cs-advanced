using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class Subtract : Operation
{
    public Subtract(
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
        if (operation == ConsoleKey.Subtract || operation == ConsoleKey.OemMinus)
        {
            return Function.Invoke(Calc.Sub, null, null);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
