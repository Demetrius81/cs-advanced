namespace Lesson5.Calculator.Console;

internal class Program
{
    static void Main(string[] args)
    {
        CalcAppBase calcApp = new CalcAppChainOfResp();
        calcApp.RunApp();

        //CalcAppBase calcApp = new CalcApp();
        //calcApp.RunApp();
    }
}
