namespace Lesson5.CalculatorWPF
{
    public class EventCalc : EventArgs
    {
        public double Answer { get; set; }
    }

    public class Calc
    {
        private readonly Stack<double> _lastStack;

        public event EventHandler<EventCalc> CalcAdvancedEventHandler = null!;


        public double Result { get; private set; }

        public Calc(double? result = 0)
        {
            Result = result ?? 0;
            _lastStack = new Stack<double>();
        }

        public void Sum(double x)
        {
            _lastStack.Push(Result);
            Result += x;
            PrintResult();
        }

        public void Sub(double x)
        {
            _lastStack.Push(Result);
            Result -= x;
            PrintResult();
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
        }

        public void Mult(double x)
        {
            _lastStack.Push(Result);
            Result *= x;
            PrintResult();
        }

        public void CancelLast()
        {
            if (_lastStack.TryPop(out double x))
            {
                Result = x;
                PrintResult();
            }
        }

        private void PrintResult()
        {
            CalcAdvancedEventHandler?.Invoke(this, new EventCalc { Answer = Result });
        }

    }
}
