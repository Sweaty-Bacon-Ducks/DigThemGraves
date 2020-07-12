using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Extensions;

public class ResizableGraphEditorNode : BaseGraphEditorNode
{
    private IGraphEditorNode nodeToResize;
    private bool resizing;
    private sbyte resizeDirection;
    private const int HANDLE_SIZE = 10;

    private static Vector2 RectPositionOffset => Vector2.one * HANDLE_SIZE;

    public ResizableGraphEditorNode(IGraphEditorNode node)
    {
        nodeToResize = node;
        DrawingSpace = nodeToResize.DrawingSpace.Scale(HANDLE_SIZE);
    }

    public override void Draw()
    {
        nodeToResize.Draw();

        var resizeHandleRects = new List<(Rect rect, sbyte direction)> {
            (new Rect(DrawingSpace.min, RectPositionOffset), -1),
            (new Rect(DrawingSpace.max - new Vector2(HANDLE_SIZE, DrawingSpace.height), RectPositionOffset), 1),
            (new Rect(DrawingSpace.min + new Vector2(0, DrawingSpace.height - HANDLE_SIZE), RectPositionOffset),1),
            (new Rect(DrawingSpace.max - new Vector2(HANDLE_SIZE, HANDLE_SIZE), RectPositionOffset), 1),
        };
        sbyte i = 0;
        foreach (var (rect, dir) in resizeHandleRects)
        {
            if (GUI.RepeatButton(rect, $"{i}"))
            {
                Debug.Log("Resizing");
                resizeDirection = dir;
                resizing = true;
            }
            i++;
        }
    }

    public override void OnEventRaised(Event e)
    {
        if (e.type == EventType.MouseDrag)
        {
            if (resizing)
            {
                nodeToResize.DrawingSpace = nodeToResize.DrawingSpace.Scale(e.delta * resizeDirection);

                DrawingSpace = nodeToResize.DrawingSpace.Scale(HANDLE_SIZE);
                DrawingSpace = DrawingSpace.Scale(e.delta * resizeDirection);
            }
            DrawingSpace = new Rect(nodeToResize.DrawingSpace.position - RectPositionOffset, DrawingSpace.size);
        }
        else if (e.type == EventType.MouseUp)
        {
            resizing = false;
        }
    }

    public override void Select()
    {

    }
}
