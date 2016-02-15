using UnityEngine;
using System.Collections;

namespace BehaviorDesigner.Runtime
{
    [System.Serializable]
    public class SharedObject : SharedVariable
    {
        public Object Value { get { return mValue; } set { mValue = value; } }
        [SerializeField]
        private Object mValue;

        public override object GetValue() { return mValue; }
        public override void SetValue(object value) { mValue = (Object)value; }

        public override string ToString() { return (mValue == null ? "null" : mValue.name); }
        // This won't work because UnityEngine.Object is the base class of SharedVariable. In a future release convert the base class of SharedVariable to object
        // public static explicit operator SharedObject(Object value) { return new SharedObject { mValue = value }; }
    }
}