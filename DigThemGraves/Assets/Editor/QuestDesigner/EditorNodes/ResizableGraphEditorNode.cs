using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ResizableGraphEditorNode : BaseGraphEditorNode
{
    private IGraphEditorNode nodeToResize;
    private Vector2 resizeVector;
    private const float HANDLE_SIZE = 20f;

    public override Rect DrawingSpace
    {
        get => Resize(nodeToResize.DrawingSpace, HANDLE_SIZE);
        protected set => base.DrawingSpace = value;
    }

    private static Rect Resize(Rect rect, float units)
    {
        return new Rect(rect.x - units,
            rect.y - units,
            rect.width + (2 * units),
            rect.height + (2 * units));
    }

    public ResizableGraphEditorNode(IGraphEditorNode node)
    {
        nodeToResize = node;
    }

    public override void Draw()
    {
        nodeToResize.Draw();

        bool clicked = new List<Rect>
        {
            new Rect(DrawingSpace.min, new Vector2(HANDLE_SIZE, HANDLE_SIZE)),
            new Rect(DrawingSpace.min - new Vector2(0, HANDLE_SIZE), new Vector2(HANDLE_SIZE, HANDLE_SIZE)),
            new Rect(DrawingSpace.max, new Vector2(HANDLE_SIZE, HANDLE_SIZE)),
            new Rect(DrawingSpace.max - new Vector2(0, HANDLE_SIZE), new Vector2(HANDLE_SIZE, HANDLE_SIZE))
        }.Select(rect => GUI.Button(rect, new GUIContent())).Any();

        if (clicked)
        {
            Debug.Log("Clicked the button");
        }
    }

    public override void OnEventRaised(Event e)
    {
    }

    public override void Select()
    {

    }
}
