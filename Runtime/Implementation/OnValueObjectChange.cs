using UnityEngine;
using UnityEngine.Events;

namespace KristinaWaldt.ValueObjects
{
    public class OnValueObjectChange : MonoBehaviour
    {
        [SerializeField]
        private ValueObject valueObject;

        [SerializeField]
        private UnityEvent changed;

        private void OnEnable()
        {
            valueObject.ValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            valueObject.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            changed?.Invoke();
        }
    }
}