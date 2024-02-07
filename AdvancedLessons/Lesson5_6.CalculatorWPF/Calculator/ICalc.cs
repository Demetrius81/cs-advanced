namespace Lesson5_6.CalculatorWPF.Calculator;

internal interface ICalc
{
    double Result { get; }

    event EventHandler<EventCalc> CalcAdvancedEventHandler;

    void CancelLast();
    void Clear();
    void Div(double x);
    void Mult(double x);
    void Sub(double x);
    void Sum(double x);
}