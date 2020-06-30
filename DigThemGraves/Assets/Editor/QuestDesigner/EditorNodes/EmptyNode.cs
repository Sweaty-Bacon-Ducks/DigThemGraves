using UnityEngine;

public class EmptyNode : BaseGraphEditorNode
{
    public static EmptyNode Instance = new EmptyNode();

    private EmptyNode() { }

    public new Rect DrawingSpace => Rect.zero;

    public new void Drag(Vector2 _) { }

    public override void Draw() { }

    public override void OnEventRaised(Event _) { }

    public override void Select() { }
}
