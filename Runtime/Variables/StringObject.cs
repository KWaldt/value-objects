using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    [CreateAssetMenu(fileName = "StringObject", menuName = "Data/Variable/String")]
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