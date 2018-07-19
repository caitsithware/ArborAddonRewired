using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace caitsithware.ArborAddons.AddonRewired.Examples
{
	using Arbor;

	[RequireComponent(typeof(InputField))]
	public class InputFieldToParameter : MonoBehaviour
	{
		[SerializeField]
		private StringParameterReference m_Parameter;

		private InputField m_InputField;

		private void Start()
		{
			m_InputField = GetComponent<InputField>();
			m_InputField.onEndEdit.AddListener(OnSubmit);

			Parameter parameter = m_Parameter.parameter;
			if (parameter != null)
			{
				m_InputField.text = parameter.stringValue;
			}
		}

		private void OnDestroy()
		{
			if (m_InputField != null)
			{
				m_InputField.onEndEdit.RemoveListener(OnSubmit);
			}
		}

		void OnSubmit(string text)
		{
			Parameter parameter = m_Parameter.parameter;
			if (parameter != null)
			{
				parameter.stringValue = text;
			}
		}
	}
}