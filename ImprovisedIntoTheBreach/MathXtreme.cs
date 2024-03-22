// namespace ImprovisedIntoTheBreach;

public static class MathXtreme
{
    public static Tuple<int, int> CoordinatesOf<T>(this T[,] array, T value)
    {
        int w = array.GetLength(0); // width
        int h = array.GetLength(1); // height

        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (array[x, y].Equals(value)) return Tuple.Create(x, y);
            }
        }

        return Tuple.Create(-1, -1);
    }
}
