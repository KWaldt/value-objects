using UnityEditor;

namespace KristinaWaldt.ValueObjects
{
    [CustomEditor(typeof(IntObject))]
    public class IntObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var t = target as IntObject;
            
            ValueObjectEditor.DrawId(serializedObject, targets);
            ValueObjectEditor.DrawScriptField(target, GetType());

            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(IntObject.id)));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("defaultValue"));

            SerializedProperty hasMinValueProperty = serializedObject.FindProperty("hasMinValue");
            EditorGUILayout.PropertyField(hasMinValueProperty);
            if (hasMinValueProperty.boolValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("minValue"));
            }

            serializedObject.ApplyModifiedProperties();
            
            ValueObjectEditor.DrawRuntimeValue(t);
        }
    }
}
