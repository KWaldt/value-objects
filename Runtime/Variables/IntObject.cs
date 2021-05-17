using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    [CreateAssetMenu(fileName = "IntObject", menuName = "Data/Variable/Int")]
    public class IntObject : GenericValueObject<int>
    {
        // NOTE: This one has a custom inspector without nameof.
        // If you want to rename a variable, please also change "IntObjectEditor".
        
        [SerializeField]
        private bool hasMinValue;

        [SerializeField]
        private int minValue;

        protected override int AdjustValue(int value)
        {
            return hasMinValue ? Mathf.Max(minValue, value) : base.AdjustValue(value);
        }

        public void Add(int value)
        {
            RuntimeValue += value;
        }
		
        public void Add(IntObject value)
        {
            Add(value.RuntimeValue);
        }

        public void Subtract(int value)
        {
            RuntimeValue -= value;
        }
		
        public void Subtract(IntObject value)
        {
            Subtract(value.RuntimeValue);
        }
    }
}