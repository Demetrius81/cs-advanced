namespace Lesson5.Calculator.Console.Interfaces;
internal interface ICalc
{
    public double Result { get; }
    void Sum(double x);
    void Sub(double x);
    void Div(double x);
    void Mult(double x);
    void CancelLast();
    event EventHandler<EventArgs> CalcEventHandler;
    event EventHandler<string> CalcAdvancedEventHandler;
}
