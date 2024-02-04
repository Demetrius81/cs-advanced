using System.Windows;

namespace Lesson5_6.CalculatorWPF.Calculator;

class SafeCalc : Calc
{
    public override void Div(double x)
    {
        try
        {
            base.Div(x);
        }
        catch (ArithmeticException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public override void CancelLast()
    {
        try
        {
            base.CancelLast();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
