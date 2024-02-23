namespace ImprovisedIntoTheBreach;

public class Grid
{
    private Vector2 _position;
    private int _cols;
    private int _rows;
    private int _cellSize;
    public GridCell[,] Cells;


    public Grid(Vector2 position, int cols, int rows, int cellSize)
    {
        _cols = cols;
        _rows = rows;
        _cellSize = cellSize;
        _position = position - new Vector2(_cols / 2 * _cellSize, _rows / 2 * _cellSize);
        Cells = new GridCell[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Cells[i, j] = new GridCell(new Vector2(_position.X + (i * _cellSize), (int)_position.Y + (j * _cellSize)), _cellSize);
            }
        }
    }


    public void Draw()
    {
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Raylib.DrawRectangleLines((int)Cells[i, j].Position.X, (int)Cells[i, j].Position.Y, _cellSize, _cellSize, Color.Black);
            }
        }
    }
}
