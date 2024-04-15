namespace ImprovisedIntoTheBreach;

public class Button : IClickable, IDrawable
{
    private Rectangle _rect;
    private string _text;
    private Action _action;

    public Action OnClick;

    public Button(Rectangle rectangle, string text, Action action)
    {
        _rect = rectangle;
        _text = text;
        _action = action;
    }

    public bool IsHovering(Vector2 mousePos)
    {
        return Raylib.CheckCollisionPointRec(mousePos, _rect);
    }

    public void Click()
    {
        _action();

        if (OnClick != null)
        {
            OnClick.Invoke();
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(_rect, Color.SkyBlue);
        Raylib.DrawText(_text, (int)_rect.X + 5, (int)_rect.Y + 5, 36, Color.Black);
    }
}

