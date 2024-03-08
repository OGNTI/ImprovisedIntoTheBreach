namespace ImprovisedIntoTheBreach;

public abstract class GameObject : IDrawable
{
    public abstract void Update(float deltaTime);
    public abstract void Draw();   
}
