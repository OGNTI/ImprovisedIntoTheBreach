
namespace ImprovisedIntoTheBreach;

public class Mech : GameObject, IClickable
{
    protected Slot _slot;

    Texture2D icon = Raylib.LoadTexture(@"IMG/CombatMech.png");

    public Mech()
    {

    }

    public bool IsHovering(Vector2 mousePos)
    {
        return false;
    }

    public void Click()
    {

    }
    
    public override void Update(float deltaTime)
    {

    }

    public override void Draw()
    {
        Raylib.DrawTexture(icon, 100,100, Color.White);
    }

}
