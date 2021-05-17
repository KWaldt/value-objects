using UnityEditor;

namespace KristinaWaldt.ValueObjects
{
    [CustomEditor(typeof(IntObject))]
    public class IntObjectEditor : Editor
    {
        private const string HasMinValuePropertyName = "hasMinValue";
        private const string MinValuePropertyName = "minValue";
        
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.UpdateIfRequiredOrScript();
            
            var t = target as IntObject;
            
            ValueObjectEditor.DrawId(serializedObject, targets);
            ValueObjectEditor.DrawScriptField(target, GetType());
            ValueObjectEditor.DrawDescription(serializedObject);

            EditorGUILayout.PropertyField(serializedObject.FindProperty(ValueObjectEditor.DefaultValuePropertyName));

            SerializedProperty hasMinValueProperty = serializedObject.FindProperty(HasMinValuePropertyName);
            EditorGUILayout.PropertyField(hasMinValueProperty);
            if (hasMinValueProperty.boolValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty(MinValuePropertyName));
            }

            serializedObject.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
            
            ValueObjectEditor.DrawRuntimeValue(t);
        }
    }
}
