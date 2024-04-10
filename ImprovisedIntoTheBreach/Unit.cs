
using Microsoft.VisualBasic;

namespace ImprovisedIntoTheBreach;

public class Unit : GameObject, IClickable
{
    protected Slot _slot;
    protected Grid _grid;
    protected Rectangle _rect;

    protected Texture2D _icon;

    protected int _maxMoveRange;
    protected int _moveRange;
    protected int _maxActionPoints;
    protected int _actionPoints;

    protected bool _isSelected = false;

    protected Color _selectedColor;


    public override void Update(float deltaTime)
    {
        if (_grid.selected == this) _grid.ShowMovementRange(_slot, _moveRange, _selectedColor);
    }

    public override void Draw()
    {
        Raylib.DrawTexture(_icon, (int)_rect.X, (int)_rect.Y, Color.White);
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public void Click()
    {
        if (_grid.selected != this) _grid.selected = this;
        else _grid.selected = null;
    }

    public void Move(Slot newSlot, Slot[,] array)
    {
        if (HasActionPoints())
        {
            //subtract moved distance from moveRange
            var currentIndex = MathXtreme.CoordinatesOf<Slot>(array, _slot);
            var targetIndex = MathXtreme.CoordinatesOf<Slot>(array, newSlot);
            int distance = Math.Abs(currentIndex.Item1 - targetIndex.Item1) + Math.Abs(currentIndex.Item2 - targetIndex.Item2);
            _moveRange -= distance;

            //Move
            _slot = newSlot;
            SetPosition();
            _actionPoints--;
        }
    }

    public void Attack()
    {

    }

    protected void SetPosition()
    {
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, _icon);
    }

    protected void ResetTurnbasedStats()
    {
        _moveRange = _maxMoveRange;
        _actionPoints = _maxActionPoints;
    }

    protected bool HasActionPoints()
    {
        if (_actionPoints > 0) return true;
        else return false;
    }
}
