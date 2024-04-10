﻿namespace ImprovisedIntoTheBreach;

public class Mech : Unit
{
    public Mech(Grid grid, Slot slot)
    {
        _selectedColor = Color.Green;
        _icon = Raylib.LoadTexture(@"IMG/CombatMech.png");
        _grid = grid;
        _slot = slot;
        _rect.Width = _icon.Width;
        _rect.Height = _icon.Height;
        SetPosition();

        _maxMoveRange = 3;
        _maxActionPoints = 2;
        ResetTurnbasedStats();
    }
}
