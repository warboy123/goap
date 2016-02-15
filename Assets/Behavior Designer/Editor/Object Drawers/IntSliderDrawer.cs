using UnityEngine;
using UnityEditor;
using BehaviorDesigner.Runtime.ObjectDrawers;

namespace BehaviorDesigner.Editor.ObjectDrawers
{
    [CustomObjectDrawer(typeof(IntSliderAttribute))]
    public class IntSliderDrawer : ObjectDrawer
    {
        public override void OnGUI(GUIContent label)
        {
            var intSliderAttribute = (IntSliderAttribute)attribute;
            value = EditorGUILayout.IntSlider(label, (int)value, intSliderAttribute.min, intSliderAttribute.max);
        }
    }
}