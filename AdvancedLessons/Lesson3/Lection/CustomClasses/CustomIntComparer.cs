namespace Lesson3;

public class CustomIntComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 == 0 || x % 2 == 1 && y % 2 == 1)
        {
            return x.CompareTo(y);
        }
        else
        {
            if (x % 2 == 1)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}