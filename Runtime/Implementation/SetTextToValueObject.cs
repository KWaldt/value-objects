using TMPro;
using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    public class SetTextToValueObject : MonoBehaviour
    {
        [SerializeField]
        private ValueObject valueObject;

        private TextMeshProUGUI textmesh;

        private void Awake()
        {
            textmesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            OnValueChanged();
        }

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
            textmesh.text = valueObject.StringOutput();
        }
    }
}