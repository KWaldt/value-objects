using System;
using System.Collections.Generic;
using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    public abstract class GenericValueObject<T> : ValueObject, ISerializationCallbackReceiver
    {
        public event Action<T> ValueChangedTo;

        // Note: If you rename this, please also change ValueObjectEditor.
        [SerializeField]
        private T defaultValue;

        private T runtimeValue;
		
        public T RuntimeValue
        {
            get => runtimeValue;
            set
            {
                if (EqualityComparer<T>.Default.Equals(value, runtimeValue))
                    return;
				
                runtimeValue = AdjustValue(value);
                CallValueChanged();
                ValueChangedTo?.Invoke(runtimeValue);
            }
        }
        
        protected virtual T AdjustValue(T value)
        {
            return value;
        }

        public override string StringOutput()
        {
            return RuntimeValue.ToString();
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            runtimeValue = AdjustValue(defaultValue);
            // runtimeValue = defaultValue;
        }

        public void SetTo(T newValue)
        {
            RuntimeValue = newValue;
        }
        
        public void ResetToDefault()
        {
            RuntimeValue = defaultValue;
        }
    }
}