namespace ImprovisedIntoTheBreach;

public interface IClickable
{
  public bool IsHovering(Vector2 mousePos);
  public void Click();
}
