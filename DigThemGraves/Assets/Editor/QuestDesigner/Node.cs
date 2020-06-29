using NUnit.Framework;
using System;
using UnityEditor;
using UnityEngine;

public class Node
{
    public Rect rect;
    public string title;
    public bool isDragged;
    public bool isSelected;

    public GUIStyle style;
    public GUIStyle defaultNodeStyle;
    public GUIStyle selectedNodeStyle;

    public ConnectionPoint inPoint;
    public ConnectionPoint outPoint;

    public Action<Node> OnRemoveNode;

    public Node(Vector2 position, float width, float height, GUIStyle nodeStyle, GUIStyle selectedStyle, GUIStyle inPointStyle, GUIStyle outPointStyle, Action<ConnectionPoint> OnClickInPoint, Action<ConnectionPoint> OnClickOutPoint, Action<Node> OnClickRemoveNode)
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
                BeginDrag(e);
                break;

            case EventType.MouseUp:
                EndDrag();
                break;

            case EventType.MouseDrag:
                DragNode(e);
                break;
        }
    }

    private void BeginDrag(Event e)
    {
        if (e.button == 0)
        {
            if (rect.Contains(e.mousePosition))
            {
                isDragged = true;
                isSelected = true;
                style = selectedNodeStyle;
                GUI.changed = true;
            }
            else
            {
                GUI.changed = true;
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
    private void EndDrag()
    {
        isDragged = false;
    }

    private void DragNode(Event e)
    {
        if (e.button == 0 && isDragged)
        {
            Drag(e.delta);
            e.Use();
            GUI.changed = true;
        }
    }
}
