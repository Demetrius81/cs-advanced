using Lesson5.Calculator.Console.Interfaces;

namespace Lesson5.Calculator.Console;
internal class CalcAppChainOfResp : CalcAppBase
{
    public CalcAppChainOfResp() : base()
    {
    }

    internal override void RunApp()
    {
        _firstNumber = InputNumber(FIRST_NUMBER_MSG);
        bool run = true;
        _calc = new Calc(_firstNumber);
        _calc.CalcAdvancedEventHandler += Calc_CalcAdvancedEventHandler;

        // Инициализируем цепочку обязанностей
        Operation operationItem =
            new Sum(
                new Subtract(
                    new Multipy(
                        new Divide(
                            new Quit(
                                new CancelLast(new ErrorMessage(null, 
                                            _calc, CalculateNums, RequestToExit, ErrorMessage), 
                                        _calc, CalculateNums, RequestToExit, ErrorMessage),
                                    _calc, CalculateNums, RequestToExit, ErrorMessage),
                                _calc, CalculateNums, RequestToExit, ErrorMessage),
                            _calc, CalculateNums, RequestToExit, ErrorMessage),
                        _calc, CalculateNums, RequestToExit, ErrorMessage),
                    _calc, CalculateNums, RequestToExit, ErrorMessage);

        while (run)
        {
            ConsoleKey operationKey = RequestToOperation();
            run = operationItem.Execute(operationKey) ?? false;

        }
    }

}
