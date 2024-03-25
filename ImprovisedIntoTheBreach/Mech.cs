
namespace ImprovisedIntoTheBreach;

public class Mech : GameObject, IClickable
{
    protected Slot _slot;
    Rectangle _rect;

    Color selectedColor = Color.Green;

    Texture2D icon = Raylib.LoadTexture(@"IMG/CombatMech.png");

    int moveRange = 4;

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

    public Mech(Slot slot)
    {
        _slot = slot;
        _rect.Width = icon.Width;
        _rect.Height = icon.Height;
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, icon);
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public void Click(Grid grid)
    {
        IsSelected = !IsSelected;
        // _slot.contentColor = selectedColor;
        if (IsSelected) grid.ShowMovementRange(_slot, moveRange, selectedColor);
        else if (!IsSelected) grid.HideMovementRange();
    }

    public override void Update(float deltaTime)
    {

    }

    public override void Draw()
    {
        Raylib.DrawTexture(icon, (int)_rect.X, (int)_rect.Y, Color.White);
    }
}
