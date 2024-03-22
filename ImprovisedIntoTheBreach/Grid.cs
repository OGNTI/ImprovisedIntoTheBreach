namespace ImprovisedIntoTheBreach;

public class Grid : IDrawable
{
    private Vector2 _position;
    private int _cols;
    private int _rows;
    private int _slotSize;
    public Slot[,] Slots;
    Rectangle gridRect;

    private int backgroundPadding = 7;
    private int slotPadding = 6;

    Color backgroundColor = Color.DarkGray;
    Color standardContentColor = Color.Gray;


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

        Slots = new Slot[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Slots[i, j] = new Slot(new Vector2
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
                Slots[i, j].Draw();
            }
        }
    }

    public void ShowMovementRange(int moveRange, Slot slot, Color color)
    {
        var index = MathXtreme.CoordinatesOf<Slot>(Slots, slot);

        for (int i = 1; i <= moveRange; i++)
        {
            if (index.Item1 + i < _cols && index.Item1 - i > 0 && index.Item2 + i < _rows && index.Item2 - i > 0)
            {
                //Horizontal
                Slots[index.Item1 + i, index.Item2].contentColor = color;
                Slots[index.Item1 - i, index.Item2].contentColor = color;

                //Vertical
                Slots[index.Item1, index.Item2 + i].contentColor = color;
                Slots[index.Item1, index.Item2 - i].contentColor = color;
            }
        }
    }

    public void HideMovementRange()
    {
        foreach (Slot s in Slots)
        {
            s.contentColor = standardContentColor;
        }
    }

    
}
