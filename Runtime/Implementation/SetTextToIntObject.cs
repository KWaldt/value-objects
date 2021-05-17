using TMPro;
using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
    public class SetTextToIntObject : MonoBehaviour
    {
        [SerializeField]
        private IntObject intObject;

        // Leading zeroes. Example padding = 3: 1 → 001, 10 → 010, 100 → 100, 1000 → 1000
        [SerializeField, Range(0, 5)]
        private int padding = 3;
        
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
            intObject.ValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            intObject.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged()
        {
            string formatString = $"D{padding}";
            textmesh.text = intObject.RuntimeValue.ToString(formatString);
        }
    }
}