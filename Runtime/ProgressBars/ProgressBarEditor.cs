#if UNITY_EDITOR
using UnityEditor;
using Rossoforge.UI.Controls.ProgressBars;
using UnityEngine;

namespace Rossoforge.UI.Controls
{
    [CustomEditor(typeof(ProgressBar))]
    public class ProgressBarEditor : Editor
    {
        SerializedProperty fillRect;
        SerializedProperty direction;
        SerializedProperty minValue;
        SerializedProperty maxValue;
        SerializedProperty wholeNumbers;
        SerializedProperty value;
        SerializedProperty onValueChanged;

        void OnEnable()
        {
            fillRect = serializedObject.FindProperty("m_FillRect");
            direction = serializedObject.FindProperty("m_Direction");
            minValue = serializedObject.FindProperty("m_MinValue");
            maxValue = serializedObject.FindProperty("m_MaxValue");
            wholeNumbers = serializedObject.FindProperty("m_WholeNumbers");
            value = serializedObject.FindProperty("m_Value");
            onValueChanged = serializedObject.FindProperty("m_OnValueChanged");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(fillRect);
            EditorGUILayout.PropertyField(direction);
            EditorGUILayout.PropertyField(minValue);
            EditorGUILayout.PropertyField(maxValue);
            EditorGUILayout.PropertyField(wholeNumbers);

            float min = minValue.floatValue;
            float max = maxValue.floatValue;

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("Value");
            if (wholeNumbers.boolValue)
            {
                value.floatValue = EditorGUILayout.IntSlider(Mathf.RoundToInt(value.floatValue), Mathf.RoundToInt(min), Mathf.RoundToInt(max));
            }
            else
            {
                value.floatValue = EditorGUILayout.Slider(value.floatValue, min, max);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.PropertyField(onValueChanged);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif