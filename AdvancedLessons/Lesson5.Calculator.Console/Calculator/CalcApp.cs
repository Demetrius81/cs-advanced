namespace Lesson5.Calculator.Console;
internal class CalcApp : CalcAppBase
{
    public CalcApp() : base()
    {
        
    }

    internal override void RunApp()
    {
        _firstNumber = InputNumber(FIRST_NUMBER_MSG);
        _calc = new Calc(_firstNumber);
        bool run = true;
        _calc.CalcAdvancedEventHandler += Calc_CalcAdvancedEventHandler;

        while (run)
        {
            ConsoleKey operation = RequestToOperation();

#pragma warning disable S2589
            switch (true)
            {
                case true when (operation == ConsoleKey.Add || operation == ConsoleKey.OemPlus):
                    _ = CalculateNums(_calc.Sum, null, null);
                    break;
                case true when (operation == ConsoleKey.Subtract || operation == ConsoleKey.OemMinus):
                    _ = CalculateNums(_calc.Sub, null, null);
                    break;
                case true when (operation == ConsoleKey.Divide):
                    _ = CalculateNums(_calc.Div, null, null);
                    break;
                case true when (operation == ConsoleKey.Multiply):
                    _ = CalculateNums(_calc.Mult, null, null);
                    break;
                case true when (operation == ConsoleKey.Escape || operation == ConsoleKey.Spacebar):
                    run = CalculateNums(null, null, RequestToExit);
                    break;
                case true when (operation == ConsoleKey.Backspace):
                    _ = CalculateNums(null, _calc.CancelLast, null);
                    break;
                default:
                    run = CalculateNums(null, null, ErrorMessage);
                    break;
            }
#pragma warning restore S2589
        }
    }
}
