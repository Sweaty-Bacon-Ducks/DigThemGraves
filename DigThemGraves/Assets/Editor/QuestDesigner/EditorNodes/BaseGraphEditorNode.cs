using UnityEngine;

public abstract class BaseGraphEditorNode : IGraphEditorNode
{
    private Rect drawingSpace;
    protected const float CONTROL_DEADZONE = 0.01f;

    public virtual Rect DrawingSpace
    {
        get => drawingSpace;
        set => drawingSpace = value;
    }

    public void Drag(Vector2 positionChange)
    {
        drawingSpace.position += positionChange.magnitude < CONTROL_DEADZONE ? Vector2.zero : positionChange;
    }

    public abstract void Draw();

    public abstract void OnEventRaised(Event e);

    public void OnNodeRemoved() { }

    public abstract void Select();

}
