using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    [CreateAssetMenu(fileName = "BoolObject", menuName = MenuPath + "Bool")]
    public class BoolObject : GenericValueObject<bool>
    {
        public void Flip()
        {
            RuntimeValue = !RuntimeValue;
        }

        public bool IsTrue()
        {
            return RuntimeValue;
        }

        public bool IsFalse()
        {
            return !RuntimeValue;
        }
    }
}