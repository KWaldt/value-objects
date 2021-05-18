using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    [CreateAssetMenu(fileName = "GameObjectObject", menuName = MenuPath + "GameObject")]
    public class GameObjectObject : GenericValueObject<GameObject>
    {
        public bool IsAssigned()
        {
            return RuntimeValue != null;
        }

        public bool IsNull()
        {
            return RuntimeValue == null;
        }

        public T GetComponent<T>() where T : Component
        {
            return IsNull() ? null : RuntimeValue.GetComponent<T>();
        }

        public override string StringOutput()
        {
            return IsAssigned() ? RuntimeValue.name : "(none)";
        }
    }
}