
namespace ImprovisedIntoTheBreach;

public class Mech : GameObject, IClickable
{
    protected Slot _slot;
    protected Grid _grid;
    Rectangle _rect;

    Color _selectedColor = Color.Green;

    Texture2D _icon = Raylib.LoadTexture(@"IMG/CombatMech.png");

    int _moveRange = 3;

    bool _isSelected = false;
    public bool IsSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            _isSelected = value;
        }
    }

    public Mech(Grid grid, Slot slot)
    {
        _grid = grid;
        _slot = slot;
        _rect.Width = _icon.Width;
        _rect.Height = _icon.Height;
        SetPosition();
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public void Click()
    {
        IsSelected = !IsSelected;
        // _slot.contentColor = selectedColor;
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

    public void Move(Slot newSlot)
    {
        _slot = newSlot;
        SetPosition();
    }

    public void SetPosition()
    {
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, _icon);
    }
}
