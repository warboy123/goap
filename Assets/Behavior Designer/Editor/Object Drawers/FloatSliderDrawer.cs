using UnityEngine;
using UnityEditor;
using BehaviorDesigner.Runtime.ObjectDrawers;

namespace BehaviorDesigner.Editor.ObjectDrawers
{
    [CustomObjectDrawer(typeof(FloatSliderAttribute))]
    public class FloatSliderDrawer : ObjectDrawer
    {
        public override void OnGUI(GUIContent label)
        {
            var floatSliderAttribute = (FloatSliderAttribute)attribute;
            value = EditorGUILayout.Slider(label, (float)value, floatSliderAttribute.min, floatSliderAttribute.max);
        }
    }
}