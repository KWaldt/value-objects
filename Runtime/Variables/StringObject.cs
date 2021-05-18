using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    [CreateAssetMenu(fileName = "StringObject", menuName = MenuPath + "String")]
    public class StringObject : GenericValueObject<string>
    {
        public bool HasValue()
        {
            return !IsEmpty();
        }
        
        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(RuntimeValue);
        }
    }
}