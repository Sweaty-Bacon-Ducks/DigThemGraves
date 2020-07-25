using AbstractionLib.QuestSystem;
using UnityEditor;
using UnityEditor.UIElements;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DigThemGraves
{
    [CustomPropertyDrawer(typeof(QuestStateTransisitonMatrix))]
    public class QuestTransitionMatrixPropertyDrawer : PropertyDrawer
    {
        private float propertyHeight;
        private const int N_ROWS = 5;
        private const float OPTION_INDENDENTATION = 0f;
        private const float OPTION_Y_OFFSET = 2f;

        private Enum ActiveMask = QuestState.Available | QuestState.Failed | QuestState.Finished;
        private Enum AvailableMask = QuestState.Failed | QuestState.Finished;
        private Enum FinishedMask = QuestState.Finished;
        private Enum FailedMask = QuestState.Failed;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            {
                //var indent = EditorGUI.indentLevel;
                //EditorGUI.indentLevel = 0;

                var headerRectposition = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
                var activeStateRect = new Rect(position.position + new Vector2(OPTION_INDENDENTATION, OPTION_Y_OFFSET + propertyHeight), position.size);
                ActiveMask = EditorGUI.EnumFlagsField(activeStateRect, "Active", ActiveMask);

                //var availableStateRect = new Rect(position.position + new Vector2(OPTION_INDENDENTATION, OPTION_Y_OFFSET + 2 * propertyHeight), position.size);
                //availableStateRect = EditorGUI.PrefixLabel(availableStateRect, GUIUtility.GetControlID(FocusType.Passive), label);
                //AvailableMask = EditorGUI.EnumFlagsField(availableStateRect, GUIContent.none, AvailableMask);

                //var failedStateRect = new Rect(position.position + new Vector2(OPTION_INDENDENTATION, OPTION_Y_OFFSET + 3 * propertyHeight), position.size);
                //failedStateRect = EditorGUI.PrefixLabel(failedStateRect, GUIUtility.GetControlID(FocusType.Passive), label);
                //FailedMask = EditorGUI.EnumFlagsField(failedStateRect, GUIContent.none, FailedMask);

                //var finishedStateRect = new Rect(position.position + new Vector2(OPTION_INDENDENTATION, OPTION_Y_OFFSET + 4 * propertyHeight), position.size);
                //finishedStateRect = EditorGUI.PrefixLabel(finishedStateRect, GUIUtility.GetControlID(FocusType.Passive), label);
                //FinishedMask = EditorGUI.EnumFlagsField(finishedStateRect, GUIContent.none, FinishedMask);

                //EditorGUI.indentLevel = indent;
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            propertyHeight = base.GetPropertyHeight(property, label);
            return N_ROWS * propertyHeight + N_ROWS * OPTION_Y_OFFSET;
        }
    }
}