using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GraphEditor : EditorWindow
{
    private List<IGraphEditorNode> nodes;
    private List<Connection> connections;

    private GUIStyle nodeStyle;
    private GUIStyle inPointStyle;
    private GUIStyle outPointStyle;
    private GUIStyle selectedNodeStyle;

    private ConnectionPoint selectedInPoint;
    private ConnectionPoint selectedOutPoint;

    private Vector2 offset;
    private Vector2 drag;

    [MenuItem("Window/Quest Designer")]
    private static void OpenWindow()
    {
        GraphEditor window = GetWindow<GraphEditor>();
        window.titleContent = new GUIContent("Quest Designer");
    }

    public GraphEditor()
    {
        nodes = new List<IGraphEditorNode>();
        connections = new List<Connection>();
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);

        inPointStyle = new GUIStyle();
        inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
        inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
        inPointStyle.border = new RectOffset(4, 4, 12, 12);

        outPointStyle = new GUIStyle();
        outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
        outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
        outPointStyle.border = new RectOffset(4, 4, 12, 12);

        selectedNodeStyle = new GUIStyle();
        selectedNodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1 on.png") as Texture2D;
        selectedNodeStyle.border = new RectOffset(12, 12, 12, 12);

    }

    private void OnGUI()
    {
        DrawGrid(20, 0.2f, Color.gray);
        DrawGrid(100, 0.4f, Color.gray);

        DrawNodes();
        //DrawConnections();

        //if (selectedInPoint != null)
        //    DrawConnectionLine(Event.current.mousePosition,
        //        selectedInPoint.rect.center);

        ProcessNodeEvents(Event.current);
        ProcessEvents(Event.current);

        GUI.changed = true;
        if (GUI.changed) Repaint();
    }

    private void DrawGrid(float gridSpacing, float gridOpacity, Color gridColor)
    {
        int widthDivs = Mathf.CeilToInt(position.width / gridSpacing);
        int heightDivs = Mathf.CeilToInt(position.height / gridSpacing);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        offset += drag * 0.05f;
        Vector3 newOffset = new Vector3(offset.x % gridSpacing, offset.y % gridSpacing, 0);

        for (int i = 0; i < widthDivs; i++)
        {
            Handles.DrawLine(new Vector3(gridSpacing * i, -gridSpacing, 0) + newOffset, new Vector3(gridSpacing * i, position.height, 0f) + newOffset);
        }

        for (int j = 0; j < heightDivs; j++)
        {
            Handles.DrawLine(new Vector3(-gridSpacing, gridSpacing * j, 0) + newOffset, new Vector3(position.width, gridSpacing * j, 0f) + newOffset);
        }

        Handles.color = Color.white;
        Handles.EndGUI();
    }

    private void DrawNodes()
    {
        foreach (var n in nodes)
            n.Draw();
    }

    private void DrawConnections()
    {
        foreach (var c in connections)
            c.Draw();
    }

    private void DrawConnectionLine(Vector2 startPosition, Vector2 endPosition)
    {
        Handles.DrawBezier(
            startPosition,
            endPosition,
            startPosition + Vector2.left * 50f,
            endPosition - Vector2.left * 50f,
            Color.white,
            null,
            2f);
        GUI.changed = true;
    }

    private void ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 1)
                {
                    ProcessContextMenu(e.mousePosition);
                }
                break;
            case EventType.MouseDrag:
                if (e.button == 0)
                {
                    OnDrag(e.delta);
                }
                break;
        }
    }

    private void ProcessContextMenu(Vector2 mousePosition)
    {
        GenericMenu genericMenu = new GenericMenu();
        var options = Enum.GetNames(typeof(NodeType));
        foreach (var op in options)
        {
            genericMenu.AddItem(new GUIContent($"Nodes/{op}"), false, () =>
            {
                var nodeType = (NodeType)Enum.Parse(typeof(NodeType), op);
                OnClickAddNode(nodeType, mousePosition);
            });
        }
        //genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
        genericMenu.ShowAsContext();
    }
    private void OnDrag(Vector2 delta)
    {
        drag = delta;

        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Drag(delta);
            }
        }

        GUI.changed = true;
    }

    private void ProcessNodeEvents(Event e)
    {
        foreach (var n in nodes)
            n.OnEventRaised(e);
    }

    private void OnClickAddNode(NodeType nodeType, Vector2 mousePosition)
    {
        var node = GraphEditorNodeFactory.Create(nodeType, mousePosition, resizable: true);
        nodes.Add(node);
    }

    private void OnClickRemoveNode(IGraphEditorNode node)
    {
        //List<Connection> connectionsToRemove = new List<Connection>();

        //for (int i = 0; i < connections.Count; i++)
        //{
        //    if (connections[i].inPoint == node.inPoint || connections[i].outPoint == node.outPoint)
        //    {
        //        connectionsToRemove.Add(connections[i]);
        //    }
        //}

        //for (int i = 0; i < connectionsToRemove.Count; i++)
        //{
        //    connections.Remove(connectionsToRemove[i]);
        //}
        //nodes.Remove(node);
    }

    private void OnClickInPoint(ConnectionPoint inPoint)
    {
        selectedInPoint = inPoint;

        if (selectedOutPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
            {
                ClearConnectionSelection();
            }
        }
    }

    private void OnClickOutPoint(ConnectionPoint outPoint)
    {
        selectedOutPoint = outPoint;

        if (selectedInPoint != null)
        {
            if (selectedOutPoint.node != selectedInPoint.node)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
            {
                ClearConnectionSelection();
            }
        }
    }

    private void OnClickRemoveConnection(Connection connection)
    {
        connections.Remove(connection);
    }

    private void CreateConnection()
    {
        connections.Add(new Connection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
    }

    private void ClearConnectionSelection()
    {
        selectedInPoint = null;
        selectedOutPoint = null;
    }
}