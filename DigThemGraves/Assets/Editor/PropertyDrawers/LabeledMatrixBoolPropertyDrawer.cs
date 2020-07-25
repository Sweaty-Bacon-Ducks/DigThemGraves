using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UIElements;

[Serializable]
public struct LabeledMatrixBool
{
    private MatrixBool matrix;
    private Dictionary<string, int> rowLabelToIndexMapping;
    private Dictionary<string, int> columnLabelToIndexMapping;

    public LabeledMatrixBool(int rowCount,
    int columnCount,
    string[] rowLabels,
    string[] columnLabels)
    {
        this.matrix = new MatrixBool(rowCount, columnCount);
        this.rowLabelToIndexMapping = rowLabels.Select((label, index) => (label, index))
            .ToDictionary(item => item.label, item => item.index);
        this.columnLabelToIndexMapping = columnLabels.Select((label, index) => (label, index))
            .ToDictionary(item => item.label, item => item.index); ;
    }

    public string[] RowLabels => rowLabelToIndexMapping.Keys.ToArray();
    public string[] ColumnLabels => columnLabelToIndexMapping.Keys.ToArray();

    public int RowCount => matrix.RowCount;
    public int ColumnCount => matrix.ColumnCount;

    public bool this[string rowLabel, string columnLabel]
    {
        get
        {
            int rowIndex = rowLabelToIndexMapping[rowLabel];
            int columnIndex = columnLabelToIndexMapping[columnLabel];
            return matrix[rowIndex, columnIndex];
        }
        set
        {
            int rowIndex = rowLabelToIndexMapping[rowLabel];
            int columnIndex = columnLabelToIndexMapping[columnLabel];
            matrix[rowIndex, columnIndex] = value;
        }
    }
}

[Serializable]
public struct MatrixBool
{
    private bool[] data;
    private int columnCount;
    private int rowCount;

    public MatrixBool(int rowCount,
        int columnCount)
    {
        this.rowCount = rowCount;
        this.columnCount = columnCount;
        this.data = new bool[rowCount * columnCount];
    }

    public int RowCount => rowCount;

    public int ColumnCount => columnCount;

    public bool this[int rowIndex, int colIndex]
    {
        get => data[(rowIndex * columnCount) + colIndex];
        set => data[(rowIndex * columnCount) + colIndex] = value;
    }
}

[CustomPropertyDrawer(typeof(LabeledMatrixBool))]
public class LabeledMatrixBoolPropertyDrawer : PropertyDrawer
{
    private int rowCount = 0;
    private int columnCount = 0;
    private float propertyHeight = 2;

    public int PrefixedIntField(Rect position, string prefix, int value)
    {
        Rect rect = EditorGUI.PrefixLabel(position,
            GUIUtility.GetControlID(FocusType.Passive),
            new GUIContent(prefix));
        return EditorGUI.IntField(rect, value);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var rowCountRect = new Rect(position.x, position.y, position.width, position.height / propertyHeight);
        var columnCountRect = new Rect(position.x, position.y + position.height / propertyHeight, position.width, position.height / propertyHeight);

        rowCount = PrefixedIntField(rowCountRect, "Row count", rowCount);
        columnCount = PrefixedIntField(columnCountRect, "Column count", columnCount);
        //Rect rowCountField = new Rect(position.position.x, position.position.y, position.size.x, position.size.y / propertyHeight);
        //Rect rowCountPrefixLabel = EditorGUI.PrefixLabel(rowCountField,
        //    GUIUtility.GetControlID(FocusType.Passive),
        //    new GUIContent("Row Count"));
        //rowCount = EditorGUI.IntField(rowCountPrefixLabel, rowCount);
        //EditorGUI.EndProperty();

        //if (rowCount > 0)
        //{
        //    Rect rowLabelsField = new Rect(position.position.x, position.position.y + position.size.y / propertyHeight, position.size.x, position.size.y / propertyHeight);
        //    EditorGUI.BeginProperty(rowCountField, label, property);
        //    Rect rowLabelsPrefixLabel = EditorGUI.PrefixLabel(rowLabelsField,
        //        GUIUtility.GetControlID(FocusType.Passive),
        //        new GUIContent("Row Labels"));
        //    rowCount = EditorGUI.(rowLabelsPrefixLabel, rowCount);
        //    EditorGUI.EndProperty();
        //}

        EditorGUI.indentLevel = indent;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return propertyHeight * base.GetPropertyHeight(property, label);
    }
}
