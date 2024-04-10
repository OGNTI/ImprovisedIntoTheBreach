namespace ImprovisedIntoTheBreach;

public class Slot: IDrawable, IClickable
{
    public Rectangle edgeRect;
    public Rectangle contentRect;

    int padding = 5;

    Color _edgeColor = Color.Black;
    Color _contentColor = Color.Gray;

    public Slot(Vector2 position, int slotSize)
    {
        edgeRect = new Rectangle(position, slotSize, slotSize);
        int size = slotSize - padding * 2;
        contentRect = new Rectangle(position + new Vector2(padding, padding), size, size);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(edgeRect, _edgeColor);
        Raylib.DrawRectangleRec(contentRect, _contentColor);
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, contentRect);
    }

    public void Click()
    {
        
    }

    public void ChangeContentColor(Color color)
    {
        _contentColor = color;
    }

    public void ChangeEdgeColor(Color color)
    {
        _edgeColor = color;
    }
}
