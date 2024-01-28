using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4;
internal class FindNumbers
{
    public static (int firstNumber, int secondNumber) FindTwoNumbersLoop(List<int> numbersList, int target)
    {
        for (int i = 0; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                if (numbersList[i] + numbersList[j] == target)
                {
                    return (numbersList[i], numbersList[j]);
                }
            }
        }

        return (0, 0);
    }

    public static (int firstNumber, int secondNumber) FindTwoNumbersHashSet(List<int> numbersList, int target)
    {
        HashSet<int> set = new();

        foreach (var num in numbersList)
        {
            int firstNum = target - num;

            if (set.Contains(firstNum))
            {
                return (firstNum, num);
            }
            else
            {
                set.Add(num);
            }
        }

        return (0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersLoop(List<int> numbersList, int target)
    {
        int iter = 0;

        for (int i = 0; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                for (int k = j + 1; k < numbersList.Count; k++)
                {
                    iter++;

                    if (numbersList[i] + numbersList[j] + numbersList[k] == target)
                    {
                        Console.WriteLine("Количество итераций = " + iter);
                        return (numbersList[i], numbersList[j], numbersList[k]);
                    }
                }

            }
        }

        return (0, 0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersHashSet(List<int> numbersList, int target)
    {
        int iter = 0;
        HashSet<int> set = new();

        for (int i = 1; i < numbersList.Count; i++)
        {
            for (int j = i + 1; j < numbersList.Count; j++)
            {
                iter++;
                int firstNum = target - numbersList[i] - numbersList[j];

                if (set.Contains(firstNum))
                {
                    Console.WriteLine("Количество итераций = " + iter);
                    return (firstNum, numbersList[i], numbersList[i]);
                }
                else
                {
                    set.Add(numbersList[i]);
                }
            }

            set.Add(numbersList[i]);
        }

        return (0, 0, 0);
    }

    public static (int firstNumber, int secondNumber, int thirdNumber) FindThreeNumbersWhileLoopWithTwoSholders(List<int> numbersList, int target)
    {
        int iter = 0;
        numbersList.Sort();

        for (int i = 0; i < numbersList.Count - 2; i++)
        {
            int leftSholder = i + 1;
            int rightSholder = numbersList.Count - 1;

            while (leftSholder < rightSholder)
            {
                iter++;
                int current = numbersList[i] + numbersList[leftSholder] + numbersList[rightSholder];

                switch (true)
                {
                    case true when current == target:
                        Console.WriteLine("Количество итераций = " + iter);
                        return (numbersList[i], numbersList[leftSholder], numbersList[rightSholder]);
                    case true when current < target:
                        leftSholder++;
                        break;
                    case true when current > target:
                        rightSholder--;
                        break;
                    default: break;
                }
            }
        }

        return (0, 0, 0);
    }
}
