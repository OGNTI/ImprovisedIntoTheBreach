namespace ImprovisedIntoTheBreach;

public class Grid
{
    private Vector2 _position;
    private int backgroundPadding = 10;
    private int slotPadding = 3;
    private int _cols;
    private int _rows;
    private int _slotSize;
    Rectangle gridRect;
    public Slot[,] SlotGrid;


    public Grid(Vector2 position, int cols, int rows, int slotSize)
    {
        _cols = cols;
        _rows = rows;
        _slotSize = slotSize;
        _position = position - new Vector2(_cols / 2 * _slotSize, _rows / 2 * _slotSize);
        gridRect = new Rectangle(_position - new Vector2(backgroundPadding,backgroundPadding),_slotSize * _cols +backgroundPadding*2 +(_cols*slotPadding),_slotSize*_rows+backgroundPadding*2+(_rows*slotPadding));
        SlotGrid = new Slot[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                SlotGrid[i, j] = new Slot(new Vector2(_position.X + (i * _slotSize) + (i*slotPadding), (int)_position.Y + (j * _slotSize) + (j*slotPadding)), _slotSize);
            }
        }
    }


    public void Draw()
    {
        Raylib.DrawRectangleRec(gridRect, Color.Beige);
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                // Raylib.DrawRectangleLines((int)SlotGrid[i, j].Position.X, (int)SlotGrid[i, j].Position.Y, _cellSize, _cellSize, Color.Black);
                SlotGrid[i, j].Draw(Color.Black);
            }
        }
    }
}
