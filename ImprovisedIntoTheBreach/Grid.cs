namespace ImprovisedIntoTheBreach;

public class Grid : GameObject
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
    Color standardEdgeColor = Color.Black;
    Color standardContentColor = Color.Gray;

    public List<Slot> SlotsInMoveRange = new();
    List<Slot> SlotsOutsideMoveRange = new();

    public Unit selected = null;

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

    public override void Update(float deltaTime)
    {


        if (selected != null)
        {
            if (Raylib.IsMouseButtonPressed(0))
            {
                SlotsOutsideMoveRange.Clear();
                foreach (Slot s in Slots)
                {
                    if (!SlotsInMoveRange.Contains(s)) SlotsOutsideMoveRange.Add(s); //does not work like imagined or at all
                }

                foreach (Slot s in SlotsInMoveRange)
                {
                    if (s.IsHovering(Raylib.GetMousePosition()))
                    {
                        selected.Move(s, Slots);
                    }
                }
                foreach (Slot s in SlotsOutsideMoveRange)
                {
                    if (s.IsHovering(Raylib.GetMousePosition()))
                    {
                        // selected = null;

                        Console.WriteLine(SlotsInMoveRange.Count);
                        Console.WriteLine(SlotsOutsideMoveRange.Count);
                    }
                }
            }
        }

        HideMovementRange();
    }

    public override void Draw()
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

        for (int i = 1; i <= moveRange; i++) //Horizontal + Vertical
        {
            if (index.Item1 + i < _cols) SlotsInMoveRange.Add(Slots[index.Item1 + i, index.Item2]); //Right
            if (index.Item1 - i >= 0) SlotsInMoveRange.Add(Slots[index.Item1 - i, index.Item2]); //Left
            if (index.Item2 + i < _rows) SlotsInMoveRange.Add(Slots[index.Item1, index.Item2 + i]); //Down
            if (index.Item2 - i >= 0) SlotsInMoveRange.Add(Slots[index.Item1, index.Item2 - i]); //Up
        }

        for (int x = 1; x <= moveRange; x++) //Diagonals
        {
            for (int y = 1; y <= moveRange - x; y++)
            {
                if (index.Item1 + x < _cols && index.Item2 + y < _rows) SlotsInMoveRange.Add(Slots[index.Item1 + x, index.Item2 + y]); //southeast
                if (index.Item1 - x >= 0 && index.Item2 + y < _rows) SlotsInMoveRange.Add(Slots[index.Item1 - x, index.Item2 + y]); //southwest
                if (index.Item1 + x < _cols && index.Item2 - y >= 0) SlotsInMoveRange.Add(Slots[index.Item1 + x, index.Item2 - y]); //northeast
                if (index.Item1 - x >= 0 && index.Item2 - y >= 0) SlotsInMoveRange.Add(Slots[index.Item1 - x, index.Item2 - y]); //northwest

            }
        }

        foreach (Slot s in SlotsInMoveRange)
        {
            s.ChangeContentColor(color);
        }
        origin.ChangeEdgeColor(color);
    }

    public void HideMovementRange()
    {
        foreach (Slot s in Slots)
        {
            s.ChangeContentColor(standardContentColor);
            s.ChangeEdgeColor(standardEdgeColor);
        }


        SlotsInMoveRange.Clear();
    }
}
