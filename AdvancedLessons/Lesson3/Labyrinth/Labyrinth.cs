namespace Lesson3;

public static class Labyrinth
{
    /**
     * Возможно я неверно Вас понял, но на семинаре угловая точка выхода из 
     * лабиринта - это два выхода плюс точка выхода, расположенная рядом, чтобы подойти к угловой точке.
     * 
     * Я в корне не согласен, что уловые точки - это два выхода из лабиринта. 
     * Это одна точка выхода. Да выйти из нее можно в разных направлениях, 
     * однако мы оперируем только координатами. Если бы у нас помимо координат был вектор движения, то сдесь я с Вами согласен.
     * Вторая точка выхода будет находиться рядом, иначе к угловой точке не подойти. 
     * В итоге мы имеем угловую точку выхода и точку выхода, находящуюся рядом.
     * Если вы со мной не согласны, предоставьте координаты точек выхода, учитывая то,
     * что за пределами массива координат нет.
     * 
     * 
     * 
     * 
     
     */


    /// <summary>
    /// Homework is strictly according to the conditions
    /// </summary>
    public static int HasExit(int startY, int startX, int startZ, int[,,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.GetLength(0) == 0 || array.GetLength(1) == 0 || array.GetLength(2) == 0)
        {
            throw new ArgumentException(nameof(array));
        }

        if (startY < 0 || startY > array.GetLength(0))
        {
            throw new ArgumentOutOfRangeException(nameof(startY));
        }

        if (startX < 0 || startX > array.GetLength(1))
        {
            throw new ArgumentOutOfRangeException(nameof(startX));
        }

        if (startZ < 0 || startZ > array.GetLength(2))
        {
            throw new ArgumentOutOfRangeException(nameof(startZ));
        }

        int[,,] arrayLabyrinth = (int[,,])array.Clone();

        if (array[startY, startX, startZ] == 1)
        {
            return -1;
        }

        Stack<Tuple<int, int, int>> stackOfCoords = new Stack<Tuple<int, int, int>>();
        stackOfCoords.Push(new Tuple<int, int, int>(startY, startX, startZ));
        int count = 0;

        while (stackOfCoords.Count > 0)
        {
            var temp = stackOfCoords.Pop();

            if (arrayLabyrinth[temp.Item1, temp.Item2, temp.Item3] == 0 && IsExit(temp.Item1, temp.Item2, temp.Item3, arrayLabyrinth))
            {
                count++;
            }

            arrayLabyrinth[temp.Item1, temp.Item2, temp.Item3] = 1;

            if (temp.Item3 - 1 >= 0 && arrayLabyrinth[temp.Item1, temp.Item2, temp.Item3 - 1] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2, temp.Item3 - 1));
            }

            if (temp.Item3 + 1 < arrayLabyrinth.GetLength(2) && arrayLabyrinth[temp.Item1, temp.Item2, temp.Item3 + 1] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2, temp.Item3 + 1));
            }

            if (temp.Item2 - 1 >= 0 && arrayLabyrinth[temp.Item1, temp.Item2 - 1, temp.Item3] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2 - 1, temp.Item3));
            }

            if (temp.Item2 + 1 < arrayLabyrinth.GetLength(1) && arrayLabyrinth[temp.Item1, temp.Item2 + 1, temp.Item3] != 1)
            {
                stackOfCoords.Push(new(temp.Item1, temp.Item2 + 1, temp.Item3));
            }

            if (temp.Item1 - 1 >= 0 && arrayLabyrinth[temp.Item1 - 1, temp.Item2, temp.Item3] != 1)
            {
                stackOfCoords.Push(new(temp.Item1 - 1, temp.Item2, temp.Item3));
            }

            if (temp.Item1 + 1 < arrayLabyrinth.GetLength(0) && arrayLabyrinth[temp.Item1 + 1, temp.Item2, temp.Item3] != 1)
            {
                stackOfCoords.Push(new(temp.Item1 + 1, temp.Item2, temp.Item3));
            }
        }

        return count;
    }

    /// <summary>
    /// Homework, advanced method
    /// </summary>
    public static (int exitsCount, List<Point>? coordinates) HasExitPromoutedHW(Point start, int[,,] array)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.GetLength(0) == 0 || array.GetLength(1) == 0)
        {
            throw new ArgumentException(nameof(array));
        }

        if (start.coordX < 0 || start.coordX > array.GetLength(0) || start.coordY < 0 || start.coordY > array.GetLength(1) || start.coordZ < 0 || start.coordZ > array.GetLength(2))
        {
            throw new ArgumentOutOfRangeException(nameof(start));
        }

        int[,,] arrayLabyrinth = (int[,,])array.Clone();

        if (arrayLabyrinth[start.coordX, start.coordY, start.coordZ] == 1)
        {
            return (-1, null);
        }

        Stack<Point> stackOfCoords = new Stack<Point>();
        List<Point> exitPoints = new List<Point>();
        stackOfCoords.Push(start);
        int count = 0;


        while (stackOfCoords.Count > 0)
        {
            var temp = stackOfCoords.Pop();

            if (arrayLabyrinth[temp.coordX, temp.coordY, temp.coordZ] == 0 && IsExit(temp, arrayLabyrinth))
            {
                count++;
                exitPoints.Add(temp);
            }

            arrayLabyrinth[temp.coordX, temp.coordY, temp.coordZ] = 1;

            if (temp.coordX - 1 >= 0 && arrayLabyrinth[temp.coordX - 1, temp.coordY, temp.coordZ] != 1)
            {
                stackOfCoords.Push(new(temp.coordX - 1, temp.coordY, temp.coordZ));
            }

            if (temp.coordX + 1 < arrayLabyrinth.GetLength(0) && arrayLabyrinth[temp.coordX + 1, temp.coordY, temp.coordZ] != 1)
            {
                stackOfCoords.Push(new(temp.coordX + 1, temp.coordY, temp.coordZ));
            }

            if (temp.coordY - 1 >= 0 && arrayLabyrinth[temp.coordX, temp.coordY - 1, temp.coordZ] != 1)
            {
                stackOfCoords.Push(new(temp.coordX, temp.coordY - 1, temp.coordZ));
            }

            if (temp.coordY + 1 < arrayLabyrinth.GetLength(1) && arrayLabyrinth[temp.coordX, temp.coordY + 1, temp.coordZ] != 1)
            {
                stackOfCoords.Push(new(temp.coordX, temp.coordY + 1, temp.coordZ));
            }

            if (temp.coordZ - 1 >= 0 && arrayLabyrinth[temp.coordX, temp.coordY, temp.coordZ - 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordX, temp.coordY, temp.coordZ - 1));
            }

            if (temp.coordZ + 1 < arrayLabyrinth.GetLength(2) && arrayLabyrinth[temp.coordX, temp.coordY, temp.coordZ + 1] != 1)
            {
                stackOfCoords.Push(new(temp.coordX, temp.coordY, temp.coordZ + 1));
            }
        }

        return (count, exitPoints);
    }

    private static bool IsExit(int x, int y, int z, int[,,] arr)
    {

        try
        {
            var _ = arr[x + 1, y, z];
            _ = arr[x - 1, y, z];

            _ = arr[x, y + 1, z];
            _ = arr[x, y - 1, z];

            _ = arr[x, y, z + 1];
            _ = arr[x, y, z - 1];
        }
        catch
        {
            arr[x, y, z] = 2;
            return true;
        }

        return false;
    }

    private static bool IsExit(Point p, int[,,] arr)
    {
        try
        {
            var _ = arr[p.coordX + 1, p.coordY, p.coordZ];
            _ = arr[p.coordX - 1, p.coordY, p.coordZ];

            _ = arr[p.coordX, p.coordY + 1, p.coordZ];
            _ = arr[p.coordX, p.coordY - 1, p.coordZ];

            _ = arr[p.coordX, p.coordY, p.coordZ + 1];
            _ = arr[p.coordX, p.coordY, p.coordZ - 1];
        }
        catch
        {
            arr[p.coordX, p.coordY, p.coordZ] = 2;
            return true;
        }

        return false;
    }
}
