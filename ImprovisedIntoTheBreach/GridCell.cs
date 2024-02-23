namespace ImprovisedIntoTheBreach;

public class GridCell
{
    public Vector2 Position;
    protected int _cellSize;
    public bool IsOccupied;

    public GridCell(Vector2 position, int cellSize)
    {
        Position = position;
        _cellSize = cellSize;
    }
}
