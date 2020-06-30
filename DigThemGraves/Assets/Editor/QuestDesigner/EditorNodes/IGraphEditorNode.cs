public interface IGraphEditorNode : IDrawable,
    ISelectable,
    IDraggable,
    IGUIEventListener
{
    void OnNodeRemoved();
}
