using System;
using UnityEditor;
using UnityEngine;

public class GraphEditorNode : IDraggable, ISelectable, IDrawable
{
    public Rect rect;
    public string title;
    private bool isDragged;
    private bool isSelected;

    public GUIStyle style;
    public GUIStyle defaultNodeStyle;
    public GUIStyle selectedNodeStyle;

    public ConnectionPoint inPoint;
    public ConnectionPoint outPoint;

    public Action<GraphEditorNode> OnRemoveNode;

    public Rect DrawingSpace => throw new NotImplementedException();

    public GraphEditorNode(Vector2 position,
        float width,
        float height,
        GUIStyle nodeStyle,
        GUIStyle selectedStyle,
        GUIStyle inPointStyle,
        GUIStyle outPointStyle,
        Action<ConnectionPoint> OnClickInPoint,
        Action<ConnectionPoint> OnClickOutPoint,
        Action<GraphEditorNode> OnClickRemoveNode)
    {
        rect = new Rect(position.x, position.y, width, height);
        style = nodeStyle;
        inPoint = new ConnectionPoint(this, ConnectionPointType.In, inPointStyle, OnClickInPoint);
        outPoint = new ConnectionPoint(this, ConnectionPointType.Out, outPointStyle, OnClickOutPoint);
        defaultNodeStyle = nodeStyle;
        selectedNodeStyle = selectedStyle;
        OnRemoveNode = OnClickRemoveNode;
    }

    public void Drag(Vector2 delta)
    {
        rect.position += delta;
    }

    public void Draw()
    {
        inPoint.Draw();
        outPoint.Draw();
        GUI.Box(rect, title, style);
    }

    public void ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                OnMouseDown(e);
                break;

            case EventType.MouseUp:
                OnMouseUp();
                break;

            case EventType.MouseDrag:
                OnMouseDrag(e);
                break;
        }
    }

    private void OnMouseDown(Event e)
    {
        if (e.button == 0)
        {
            if (rect.Contains(e.mousePosition))
            {
                isDragged = true;
                isSelected = true;
                style = selectedNodeStyle;
            }
            else
            {
                isSelected = false;
                style = defaultNodeStyle;
            }
        }

        if (e.button == 1 && isSelected && rect.Contains(e.mousePosition))
        {
            ProcessContextMenu();
            e.Use();
        }
    }

    private void ProcessContextMenu()
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Remove node"), false, OnClickRemoveNode);
        genericMenu.ShowAsContext();
    }

    private void OnClickRemoveNode()
    {
        OnRemoveNode?.Invoke(this);
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnMouseDrag(Event e)
    {
        if (e.button == 0 && isDragged)
        {
            Drag(e.delta);
            e.Use();
            GUI.changed = true;
        }
    }

    public void Select()
    {
        throw new NotImplementedException();
    }
}
