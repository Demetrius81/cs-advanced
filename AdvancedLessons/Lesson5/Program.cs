using Lesson5.Lections;
using System.Reflection.Emit;

namespace Lesson5;

internal class Program
{
    static void Main(string[] args)
    {
        Part2.Run(args);
    }

    //private void Plus_Button_Click(object sender, RoutedEventArgs e)
    //{
    //    string inpt = InputText.Text;
    //    Answer.Content = inpt;
    //}

    //private void InputText_TextChanged(object sender, TextChangedEventArgs e)
    //{
    //    string str = InputText.Text;
    //    char last = str[^1];
    //    if (last < '0' || last > '9')
    //    {
    //        str = str.Remove(str.Length - 1);
    //    }
    //    InputText.Text = str;
    //}

    //<TextBox HorizontalAlignment = "Left" TextChanged="InputText_TextChanged" Name="InputText" FontSize="48" Text="TextBox" VerticalAlignment="Top" Width="300" Height="100" Margin="10,65,0,0"/>
    //    <Label Content = "Label" Name="Answer" FontSize="48" VerticalAlignment="Top" HorizontalAlignment="Left" Height="100" Width="300" Margin="315,65,0,0"/>

    //    <Button Content = "Плюс" Name="Add" Click="Plus_Button_Click" HorizontalAlignment="Left" Margin="10,265,0,0" VerticalAlignment="Top" Height="77" Width="217"/>
    //    <Button Content = "Минус" Name="Sub" HorizontalAlignment="Left" Margin="10,347,0,0" VerticalAlignment="Top" Height="77" Width="217"/>
    //    <Button Content = "Умножить" Name="Mult" HorizontalAlignment="Left" Margin="454,265,0,0" VerticalAlignment="Top" Height="77" Width="217"/>
    //    <Button Content = "Разделить" Name="Div" HorizontalAlignment="Left" Margin="232,265,0,0" VerticalAlignment="Top" Height="77" Width="217"/>

}
