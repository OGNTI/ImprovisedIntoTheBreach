namespace ImprovisedIntoTheBreach;

public class Slot: IDrawable
{
    Rectangle edgeRect;
    public Rectangle contentRect;

    private int padding = 5;

    Color edgeColor = Color.Black;
    Color contentColor = Color.Gray;

    public Slot(Vector2 position, int slotSize)
    {
        edgeRect = new Rectangle(position, slotSize, slotSize);
        int size = slotSize - padding * 2;
        contentRect = new Rectangle(position + new Vector2(padding, padding), size, size);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(edgeRect, edgeColor);
        Raylib.DrawRectangleRec(contentRect, contentColor);
    }

}
