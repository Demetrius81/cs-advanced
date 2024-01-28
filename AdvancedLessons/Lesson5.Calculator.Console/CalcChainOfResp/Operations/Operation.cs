using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal abstract class Operation
{
    internal Operation? NextInstance { get; init; }
    internal Func<Action<double>?, Action?, Func<bool>?, bool> Function { get; init; }
    internal ICalc Calc { get; init; }
    internal Func<bool> Quit { get; init; }
    internal Func<bool> Error { get; init; }

    protected Operation(Operation? operation,
                    ICalc calc,
                    Func<Action<double>?, Action?, Func<bool>?, bool> func,
                    Func<bool> quit,
                    Func<bool> error)
    {
        NextInstance = operation;
        Function = func;
        Quit = quit;
        Error = error;
        Calc = calc;
    }

    public abstract bool? Execute(ConsoleKey operation);
}
