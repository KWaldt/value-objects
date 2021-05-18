using System;
using UnityEngine;

namespace KristinaWaldt.ValueObjects
{
	/// <summary>
	/// This is a non-generic class. This means it can be assigned in the inspector.
	/// </summary>
	public abstract class ValueObject : ScriptableObject
	{
		public const string MenuPath = "Data/Variable/";
		public event Action ValueChanged;
		
		// Note: If you rename this, please also change ValueObjectEditor.
		[SerializeField, TextArea]
		private string description;

		[HideInInspector]
		public string id = GetRandomId();
		
		public static string GetRandomId()
		{
			return Guid.NewGuid().ToString();
		}
		
		protected void CallValueChanged()
		{
			ValueChanged?.Invoke();
		}

		public abstract string StringOutput();
	}
}
