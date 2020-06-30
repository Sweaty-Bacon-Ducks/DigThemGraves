using UnityEngine;

public static class GraphEditorNodeFactory
{
    public static IGraphEditorNode Create(NodeType nodeType, Vector2 position, bool resizable = false)
    {
        Debug.Log($"Node Position: {position}");
        IGraphEditorNode createdNode = EmptyNode.Instance; ;
        switch (nodeType)
        {
            case NodeType.Text:
                createdNode = new TextNode(position, new Vector2(100, 100));
                break;
        }

        if (resizable)
        {
            createdNode = AsResizable(createdNode);
        }

        return createdNode;
    }

    private static IGraphEditorNode AsResizable(IGraphEditorNode node)
    {
        return new ResizableGraphEditorNode(node);
    }
}
