namespace ImprovisedIntoTheBreach;

public class Button : IClickable, IDrawable
{
    private Rectangle _rect;
    private Vector2 _pos;
    private string _text;
    private Action _action;
    private int _textLength;

    public Action OnClick;
    

    public Button(Vector2 position, string text, int fontSize, Action action)
    {
        _pos = position;
        _text = text;
        _action = action;

        _textLength = Raylib.MeasureText(text, fontSize);

        _rect = new(_pos.X, _pos.Y, _textLength + 10, fontSize + 5);
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

