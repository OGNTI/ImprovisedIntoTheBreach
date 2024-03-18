
namespace ImprovisedIntoTheBreach;

public class Mech : GameObject, IClickable
{
    protected Slot _slot;
    Rectangle _rect;

    Texture2D icon = Raylib.LoadTexture(@"IMG/CombatMech.png");

    float moveRange = 4;

    public Mech(Slot slot)
    {
        _slot = slot;
        _rect.Width = icon.Width;
        _rect.Height = icon.Height;
        _rect.Position = CenterTexture(_slot.contentRect, icon);
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public void Click()
    {
        Console.WriteLine("gae");
    }

    public override void Update(float deltaTime)
    {

    }

    public override void Draw()
    {
        Raylib.DrawTexture(icon, (int)_rect.X, (int)_rect.Y, Color.White);
        // Raylib.DrawTextureEx(icon, _rect.Position, 0, 1, Color.White);
    }


    Vector2 CenterTexture(Rectangle rect, Texture2D texture)
    {
        return new Vector2
        (
            (rect.X + rect.Width / 2) - texture.Width/2,
            (rect.Y + rect.Height / 2) - texture.Height/2
        );
    }
}
