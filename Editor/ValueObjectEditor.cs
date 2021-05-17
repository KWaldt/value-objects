using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KristinaWaldt.ValueObjects
{
    [CustomEditor(typeof(ValueObject), true), CanEditMultipleObjects]
    public class ValueObjectEditor : Editor
    {
        public const string DescriptionPropertyName = "description";
        public const string DefaultValuePropertyName = "defaultValue";
        
        public override void OnInspectorGUI()
        {
            DrawId(serializedObject, targets);
            base.OnInspectorGUI();
            var t = target as ValueObject;

            DrawRuntimeValue(t);
        }

        public static void DrawDescription(SerializedObject serializedObject)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(DescriptionPropertyName));
        }

        public static void DrawScriptField(Object target, Type type)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((ScriptableObject)target), type);
            GUI.enabled = true;
        }
        
        public static void DrawId(SerializedObject serializedObject, Object[] targets)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ValueObject.id)), GUIContent.none);
            if (GUILayout.Button("Generate New Id"))
            {
                foreach (Object target in targets)
                {
                    var targetObject = new SerializedObject(target);
                    targetObject.FindProperty(nameof(ValueObject.id)).stringValue = ValueObject.GetRandomId();
                    targetObject.ApplyModifiedProperties();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        public static void DrawRuntimeValue(ValueObject t)
        {
            var runtimeProperty = t.GetType().GetProperty(nameof(GenericValueObject<int>.RuntimeValue));
            if (runtimeProperty == null)
                return;
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField($"Runtime Value: {runtimeProperty.GetValue(t)}");
            DrawUpdateNote();
        }

        public static void DrawUpdateNote()
        {
            EditorGUILayout.LabelField("The RuntimeValue text only updates itself when the inspector is selected. You might need to hover over it with the mouse.", EditorStyles.helpBox);
        }
    }
}
