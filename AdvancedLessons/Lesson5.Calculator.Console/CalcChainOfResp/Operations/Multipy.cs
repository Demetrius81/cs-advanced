using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class Multipy : Operation
{
    public Multipy(
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
        if (operation == ConsoleKey.Multiply)
        {
            return Function.Invoke(Calc.Mult, null, null);
        }
        else
        {
            return NextInstance?.Execute(operation);
        }
    }
}
