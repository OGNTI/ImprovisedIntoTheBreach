namespace ImprovisedIntoTheBreach;

public class Grid : GameObject
{
    Vector2 _position;
    int _cols;
    int _rows;
    int _slotSize;
    public Slot[,] Slots;
    Rectangle _gridRect;

    int _backgroundPadding = 7;
    int _slotPadding = 6;

    Color _backgroundColor = Color.DarkGray;
    Color _standardEdgeColor = Color.Black;
    Color _standardContentColor = Color.Gray;

    public List<Slot> SlotsInMoveRange = new();
    public List<Slot> SlotsInAttackRange = new();

    public Unit selected = null;

    public int turn = 1;

    public Grid(Vector2 position, int cols, int rows, int slotSize)
    {
        _cols = cols;
        _rows = rows;
        _slotSize = slotSize;
        _position = position - new Vector2(_cols / 2 * _slotSize, _rows / 2 * _slotSize);

        _gridRect = new Rectangle
        (
            _position - new Vector2(_backgroundPadding, _backgroundPadding),
            new Vector2
            (
            (_slotSize * _cols) + (_backgroundPadding * 2) + ((_cols - 1) * _slotPadding),
            (_slotSize * _rows) + (_backgroundPadding * 2) + ((_rows - 1) * _slotPadding)
            )
        );

        Slots = new Slot[_cols, _rows];

        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Slots[i, j] = new Slot(new Vector2
                    (
                        _position.X + (i * _slotSize) + (i * _slotPadding),
                        _position.Y + (j * _slotSize) + (j * _slotPadding)
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
                foreach (Slot s in SlotsInMoveRange)
                {
                    if (s.IsHovering(Raylib.GetMousePosition()))
                    {
                        selected.Move(s, Slots);
                    }
                }
            }
        }

        HideMovementRange();
    }

    public override void Draw()
    {
        Raylib.DrawRectangleRec(_gridRect, _backgroundColor);
        for (int i = 0; i < _cols; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Slots[i, j].Draw();
            }
        }

        Raylib.DrawText("Turn: " + turn.ToString(), (int)_gridRect.X + 20, (int)_gridRect.Y - 50, 40, Color.Black);
    }

    public void ShowMovementRange(Slot origin, int moveRange, Color moveColor, int attackRange)
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

        for (int i = 1; i <= attackRange; i++) //Attack
        {
            if (index.Item1 + i < _cols) SlotsInAttackRange.Add(Slots[index.Item1 + i, index.Item2]); //Right
            if (index.Item1 - i >= 0) SlotsInAttackRange.Add(Slots[index.Item1 - i, index.Item2]); //Left
            if (index.Item2 + i < _rows) SlotsInAttackRange.Add(Slots[index.Item1, index.Item2 + i]); //Down
            if (index.Item2 - i >= 0) SlotsInAttackRange.Add(Slots[index.Item1, index.Item2 - i]); //Up
        }

        foreach (Slot s in SlotsInMoveRange)
        {
            s.ChangeContentColor(moveColor);
        }
        origin.ChangeEdgeColor(moveColor);

        foreach (Slot s in SlotsInAttackRange)
        {
            s.ChangeContentColor(Color.Red);
        }
    }

    public void HideMovementRange()
    {
        foreach (Slot s in Slots)
        {
            s.ChangeContentColor(_standardContentColor);
            s.ChangeEdgeColor(_standardEdgeColor);
        }

        SlotsInMoveRange.Clear();
        SlotsInAttackRange.Clear();
    }

    public float GetRightSide()
    {
        return _position.X + _gridRect.Width;
    }

    public void NextTurn(List<Unit> units)
    {
        turn++;
        foreach (Unit u in units)
        {
            u.ResetTurnbasedStats();
        }
    }
}
