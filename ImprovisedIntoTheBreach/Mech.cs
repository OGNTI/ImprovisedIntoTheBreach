namespace ImprovisedIntoTheBreach;

public class Mech : Unit
{
    Color _selectedColor = Color.Green;


    public Mech(Grid grid, Slot slot)
    {
        _icon = Raylib.LoadTexture(@"IMG/CombatMech.png");
        _grid = grid;
        _slot = slot;
        _rect.Width = _icon.Width;
        _rect.Height = _icon.Height;
        SetPosition();

        _maxMoveRange = 3;
        _maxActionPoints = 1;
        ResetTurnbasedStats();
    }

    public override void Update(float deltaTime)
    {
        if (IsSelected) _grid.ShowMovementRange(this, _slot, _moveRange, _selectedColor);
        else if (!IsSelected) _grid.HideMovementRange();
    }

    public override void Draw()
    {
        Raylib.DrawTexture(_icon, (int)_rect.X, (int)_rect.Y, Color.White);
    }

    public override bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public override void Click()
    {
        IsSelected = !IsSelected;
        _slot.ChangeContentColor(Color.DarkGreen);
    }

    public void Move(Slot newSlot, Slot[,] array)
    {
        //subtract moved distance from moveRange
        var currentIndex = MathXtreme.CoordinatesOf<Slot>(array, _slot);
        var targetIndex = MathXtreme.CoordinatesOf<Slot>(array, newSlot);
        int distance = Math.Abs(currentIndex.Item1 - targetIndex.Item1) + Math.Abs(currentIndex.Item2 - targetIndex.Item2);
        _moveRange -= distance;

        //Move
        _slot = newSlot;
        SetPosition();
    }

    public void Attack()
    {

    }

    public void SetPosition()
    {
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, _icon);
    }

    void ResetTurnbasedStats()
    {
        _moveRange = _maxMoveRange;
        _actionPoints = _maxActionPoints;
    }
}
