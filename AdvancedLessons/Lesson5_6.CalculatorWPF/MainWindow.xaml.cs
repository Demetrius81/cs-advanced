using Lesson5_6.CalculatorWPF.Calculator;
using System.Windows;

namespace Lesson5_6.CalculatorWPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ICalc calc;

    public MainWindow()
    {
        InitializeComponent();
        calc = new SafeCalc();
        calc.CalcAdvancedEventHandler += Calc_CalcAdvancedEventHandler;
    }

    private void Calc_CalcAdvancedEventHandler(object? sender, EventCalc e)
    {
        Answer.Content = e.Answer;
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        bool parse = double.TryParse(InputText.Text, out double value);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string name = (e.Source as FrameworkElement).Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        if (!parse)
        {
            MessageBox.Show("Неверно ввели данные");
        }

        switch (name)
        {

            case "Add":
                calc.Sum(value);
                break;
            case "Sub":
                calc.Sub(value);
                break;
            case "Mult":
                calc.Mult(value);
                break;
            case "Div":
                calc.Div(value);
                break;
            case "Cancel":
                calc.CancelLast();
                break;
            case "Clear":
                calc.Clear();
                InputText.Clear();
                break;
            default:
                MessageBox.Show("Ошибка пользователя.");
                InputText.Clear();
                break;
        }
    }
}