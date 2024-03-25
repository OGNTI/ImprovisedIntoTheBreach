// namespace ImprovisedIntoTheBreach;

public static class MathXtreme
{
    public static Vector2 CenterTexture(Rectangle rect, Texture2D texture)
    {
        return new Vector2
        (
            (rect.X + rect.Width / 2) - texture.Width / 2,
            (rect.Y + rect.Height / 2) - texture.Height / 2
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
}
