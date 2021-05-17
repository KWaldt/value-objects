using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    public class AssignToGameObjectObject : MonoBehaviour
    {
        [SerializeField]
        private GameObjectObject gameObjectObject;

        [SerializeField]
        private bool canOverride = true;

        private void Awake()
        {
            if (gameObjectObject.IsAssigned() && !canOverride)
                return;
            
            gameObjectObject.SetTo(gameObject);
        }
    }
}