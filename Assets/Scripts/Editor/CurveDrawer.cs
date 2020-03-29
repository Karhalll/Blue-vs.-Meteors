using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CurveAttribute))]
public class CurveDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        CurveAttribute curve = attribute as CurveAttribute;
        if (property.propertyType == SerializedPropertyType.AnimationCurve)
        {
            if (curve.b) EditorGUI.CurveField(position, property, Color.red, new Rect(curve.PosX, curve.PosY, curve.RangeX, curve.RangeY));
        }
    }
}
