namespace ImprovisedIntoTheBreach;

public class Bug : Unit
{
    public Bug(Grid grid, Slot slot)
    {
        _selectedColor = Color.Red;
        _icon = Raylib.LoadTexture(@"IMG/Scorpion.png");
        _grid = grid;
        _slot = slot;
        _rect.Width = _icon.Width;
        _rect.Height = _icon.Height;
        SetPosition();

        _maxMoveRange = 4;
        _maxActionPoints = 2;
        ResetTurnbasedStats();
    }
}
