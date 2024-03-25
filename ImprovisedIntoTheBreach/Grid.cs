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

    public List<Slot> SlotsInMoveRange = new();


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

    public void ShowMovementRange(Slot origin, int moveRange, Color color)
    {
        var index = MathXtreme.CoordinatesOf<Slot>(Slots, origin);

        for (int i = 1; i <= moveRange; i++)
        {
            if (index.Item1 + i < _cols) SlotsInMoveRange.Add(Slots[index.Item1 + i, index.Item2]); //Right
            if (index.Item1 - i > 0) SlotsInMoveRange.Add(Slots[index.Item1 - i, index.Item2]); //Left
            if (index.Item2 + i < _rows) SlotsInMoveRange.Add(Slots[index.Item1, index.Item2 + i]); //Down
            if (index.Item2 - i > 0) SlotsInMoveRange.Add(Slots[index.Item1, index.Item2 - i]); //Up
        }

        foreach (Slot s in SlotsInMoveRange)
        {
            s.ChangeContentColor(color);
        }
    }

    public void HideMovementRange()
    {
        foreach (Slot s in Slots)
        {
            s.ChangeContentColor(standardContentColor);
        }

        SlotsInMoveRange.Clear();
    }


}
