using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class Calc : ICalc
{
    private readonly Stack<double> _lastStack;

    public event EventHandler<EventArgs> CalcEventHandler = null!;
    public event EventHandler<string> CalcAdvancedEventHandler = null!;


    public double Result { get; private set; }

    internal Calc(double? result = 0)
    {
        Result = result ?? 0;
        _lastStack = new Stack<double>();
    }

    public void Sum(double x)
    {
        _lastStack.Push(Result);
        Result += x;
        PrintResult();
        PrintResult("+");
    }

    public void Sub(double x)
    {
        _lastStack.Push(Result);
        Result -= x;
        PrintResult();
        PrintResult("-");
    }

    public void Div(double x)
    {
        if (x == 0)
        {
            throw new ArithmeticException("Divide by zero");
        }

        _lastStack.Push(Result);
        Result /= x;
        PrintResult();
        PrintResult("/");
    }

    public void Mult(double x)
    {
        _lastStack.Push(Result);
        Result *= x;
        PrintResult();
        PrintResult("*");
    }

    public void CancelLast()
    {
        if (_lastStack.TryPop(out double x))
        {
            Result = x;
            PrintResult();
            PrintResult("Cancel last operation");
        }
    }

    private void PrintResult(string operation)
    {
        CalcAdvancedEventHandler?.Invoke(this, operation);
    }

    private void PrintResult()
    {
        CalcEventHandler?.Invoke(this, new EventArgs());
    }

}
