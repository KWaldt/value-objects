using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    // This is a hacky way of "fixing" the Unity 2020 issue where the Value Objects reset on every load.
    // (Still not sure if it's new intended behaviour or not but whatever.)
    // This singleton lives outside of your scene and makes sure that the Value Objects are never dereferenced.
    
    // HOW TO USE
    // Put the component on a new object in your first scene.
    // (If you have multiple possible start scenes make it into a prefab and paste it into every scene.)
    // Drop all the value objects you want to use into the array.

    public class Referencer : MonoBehaviour
	{
		public static Referencer Instance { get; private set; }
        
        // The valueObjects aren't used anywhere, but they are necessary to keep the reference alive.
        public ValueObject[] valueObjects;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }
	}
}
