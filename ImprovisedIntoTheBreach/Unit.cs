
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


    public override void Update(float deltaTime)
    {

    }

    public override void Draw()
    {

    }

    public virtual bool IsHovering(Vector2 mousePos)
    {
        return false;
    }

    public virtual void Click()
    {

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

    public void SetPosition()
    {
        _rect.Position = MathXtreme.CenterTexture(_slot.contentRect, _icon);
    }

    void ResetTurnbasedStats()
    {
        _moveRange = _maxMoveRange;
        _actionPoints = _maxActionPoints;
    }

    bool HasActionPoints()
    {
        if (_actionPoints > 0) return true;
        else return false;
    }
}
