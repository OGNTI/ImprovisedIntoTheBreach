using ImprovisedIntoTheBreach;

public static class MathXtreme
{
    public static Vector2 CenterTexture(Rectangle rect, Texture2D texture)
    {
        return new Vector2
        (
            (rect.X + rect.Width / 2) - (texture.Width / 2),
            (rect.Y + rect.Height / 2) - (texture.Height / 2)
        );
    }

    public static Tuple<int, int> CoordinatesOf<T>(this T[,] array, T value) //Get index of object in 2D array
    {
        int w = array.GetLength(0); // width
        int h = array.GetLength(1); // height

        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (array[x, y].Equals(value)) return Tuple.Create(x, y); //Compare object to everything in array
            }
        }

        return Tuple.Create(-1, -1);
    }

    public static int GetDistanceInGrid(Slot[,] array, Slot origin, Slot target)
    {
        var currentIndex = MathXtreme.CoordinatesOf<Slot>(array, origin);
        var targetIndex = MathXtreme.CoordinatesOf<Slot>(array, target);
        int distance = Math.Abs(currentIndex.Item1 - targetIndex.Item1) + Math.Abs(currentIndex.Item2 - targetIndex.Item2);

        return distance;
    }
}
