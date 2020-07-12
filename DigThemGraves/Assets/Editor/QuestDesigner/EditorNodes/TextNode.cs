using UnityEngine;

public class TextNode : BaseGraphEditorNode
{
    private const string DEFAULT_TEXT = "Write your text here!";
    private string text;
    private GUIStyle textStyle;

    public GUIStyle TextStyle
    {
        get
        {
            if (textStyle is null)
            {
                var defaultStyle = new GUIStyle
                {
                    fontSize = 14
                };
                textStyle = defaultStyle;
            }
            return textStyle;
        }
    }

    public TextNode(Vector2 position, Vector2 size)
    {
        text = DEFAULT_TEXT;
        DrawingSpace = new Rect(position, size);
    }

    public TextNode(Vector2 position, Vector2 size, GUIStyle textStyle) : this(position, size)
    {
        this.textStyle = textStyle;
    }

    public override void Draw()
    {
        text = GUI.TextArea(DrawingSpace, text);
    }

    public override void OnEventRaised(Event e)
    {

    }

    public override void Select()
    {

    }
}
