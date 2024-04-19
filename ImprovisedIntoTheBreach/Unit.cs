
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
    protected int _maxHealthPoints;
    protected int _healthPoints;
    protected int _damage;
    protected int _attackRange;

    protected bool _isSelected = false;

    protected Color _selectedColor;


    public override void Update(float deltaTime)
    {
        if (_grid.selected == this) _grid.ShowMovementRange(_slot, _moveRange, _selectedColor, _attackRange);
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
            int distance = MathXtreme.GetDistanceInGrid(array, _slot, newSlot);
            _moveRange -= distance;

            //Move
            _slot = newSlot;
            SetPosition();
            _actionPoints--;
        }
    }

    public void Attack(Unit target)
    {
        if (HasActionPoints())
        {
            target.TakeDamage(_damage);
        }
    }

    protected void SetPosition()
    {
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, _icon);
    }

    public void ResetTurnbasedStats()
    {
        _moveRange = _maxMoveRange;
        _actionPoints = _maxActionPoints;
    }

    protected bool HasActionPoints()
    {
        if (_actionPoints > 0) return true;
        else return false;
    }

    public void TakeDamage(int dmg)
    {
        _healthPoints -= dmg;
        Console.WriteLine(_healthPoints);
    }
}
