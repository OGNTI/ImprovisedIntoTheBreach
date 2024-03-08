namespace ImprovisedIntoTheBreach;

public class Grid: IDrawable
{
    private Vector2 _position;
    private int _cols;
    private int _rows;
    private int _slotSize;
    public Slot[,] SlotGrid;
    Rectangle gridRect;

    private int backgroundPadding = 7;
    private int slotPadding = 4;

    Color backgroundColor = Color.Beige;
    Color slotColor = Color.LightGray;


    public Grid(Vector2 position, int cols, int rows, int slotSize)
    {
        _cols = cols;
        _rows = rows;
        _slotSize = slotSize;
        _position = position - new Vector2(_cols / 2 * _slotSize, _rows / 2 * _slotSize);

        gridRect = new Rectangle
        (
            _position - new Vector2(backgroundPadding, backgroundPadding),
            new Vector2
            (
            (_slotSize * _cols) + (backgroundPadding * 2) + ((_cols - 1) * slotPadding),
            (_slotSize * _rows) + (backgroundPadding * 2) + ((_rows - 1) * slotPadding)
            )
        );

        SlotGrid = new Slot[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                SlotGrid[i, j] = new Slot(new Vector2
                    (
                        _position.X + (i * _slotSize) + (i * slotPadding), 
                        _position.Y + (j * _slotSize) + (j * slotPadding)
                    ), 
                    _slotSize
                );
            }
        }
    }


    public void Draw()
    {
        Raylib.DrawRectangleRec(gridRect, backgroundColor);
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                SlotGrid[i, j].Draw();
            }
        }
    }
}
