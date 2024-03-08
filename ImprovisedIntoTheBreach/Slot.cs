namespace ImprovisedIntoTheBreach;

public class Slot
{
    public Vector2 Position;
    private int padding = 5;
    protected int _slotSize;
    public Color SlotColor;
    Rectangle slotRect;
    Rectangle contentRect;

    public Slot(Vector2 position, int slotSize)
    {
        // Position = position;
        // _slotSize = slotSize;
        slotRect = new Rectangle(position, slotSize, slotSize);
        contentRect = new Rectangle(position+ new Vector2(padding,padding), slotSize-padding*2, slotSize-padding*2);
    }

    public void Draw(Color color)
    {
        // Raylib.DrawRectangle((int)Position.X, (int)Position.Y, _slotSize, _slotSize, color);
        Raylib.DrawRectangleRec(slotRect, color);
        Raylib.DrawRectangleRec(contentRect, Color.LightGray);
    }
}
