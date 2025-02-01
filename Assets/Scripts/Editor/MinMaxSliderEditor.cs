using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(InRange))]
public class MinMaxSliderEditor : PropertyDrawer
{
    private InRange _InRange;
    private Vector2 _value;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (_InRange == null)
        {
            _InRange = attribute as InRange;
        }
        if (property.propertyType == SerializedPropertyType.Vector2)
        {
            _value = property.vector2Value;
            EditorGUILayout.LabelField(label);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.MinMaxSlider("In range:", ref _value.x, ref _value.y, _InRange.minLimit, _InRange.maxLimit);
            EditorGUILayout.Vector2Field("Value:", _value);
            property.vector2Value = _value;
            property.serializedObject.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
        }  
    }
}