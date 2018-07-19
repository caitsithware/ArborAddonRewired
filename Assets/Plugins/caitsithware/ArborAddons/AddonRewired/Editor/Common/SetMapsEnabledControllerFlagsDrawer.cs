using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace caitsithware.ArborAddons.AddonRewiredEditor
{
	using caitsithware.ArborAddons.AddonRewired;

	[CustomPropertyDrawer(typeof(SetMapsEnabledControllerFlags))]
	public class SetMapsEnabledControllerFlagsDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			label = EditorGUI.BeginProperty(position, label, property);

			SetMapsEnabledControllerFlags flags = (SetMapsEnabledControllerFlags)property.intValue;
			EditorGUI.BeginChangeCheck();
			flags = (SetMapsEnabledControllerFlags)EditorGUI.EnumFlagsField(position, label, flags);
			if (EditorGUI.EndChangeCheck())
			{
				property.intValue = (int)flags;
			}

			EditorGUI.EndProperty();
		}
	}
}