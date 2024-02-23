namespace ImprovisedIntoTheBreach;

public class Grid
{
    protected Vector2 _position;
    protected int _cols;
    protected int _rows;
    protected int _cellSize;
    public Vector2[,] actualgrid;


    public Grid(Vector2 position, int cols, int rows, int cellSize)
    {
        _cols = cols;
        _rows = rows;
        _cellSize = cellSize;
        _position = position - new Vector2(_cols / 2 * _cellSize, _rows / 2 * _cellSize);
        actualgrid = new Vector2[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                actualgrid[i, j] = new Vector2((int)_position.X + (i * _cellSize), (int)_position.Y + (j * _cellSize));
            }
        }
    }


    public void Draw()
    {
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Raylib.DrawRectangleLines((int)_position.X + (i * _cellSize), (int)_position.Y + (j * _cellSize), _cellSize, _cellSize, Color.Black);
            }
        }
    }
}
