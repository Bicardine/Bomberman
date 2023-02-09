using System;
using UnityEngine;

namespace Bomberman.Model.Data
{
    [Serializable]
    public class PositiveIntData
#if UNITY_EDITOR
    : ISerializationCallbackReceiver
#endif
    {
        [SerializeField] private int _value;

        public int Value => _value;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (_value < 0)
                _value = 0;
        }

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize() => OnValidate();
#endif
    }
}

