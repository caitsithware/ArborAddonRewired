	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired
{
	using Arbor;
	using Rewired.UI.ControlMapper;

	[AddBehaviourMenu("Rewired/ControlMapper/RewiredControlMapperClose")]
	[AddComponentMenu("")]
	public class RewiredControlMapperClose : StateBehaviour
	{
		[ClassExtends(typeof(ControlMapper))]
		[SerializeField]
		private FlexibleComponent m_ControlMapper = new FlexibleComponent();

		[SerializeField]
		private FlexibleBool m_SaveOnClose = new FlexibleBool(false);

		// Use this for enter state
		public override void OnStateBegin()
		{
			ControlMapper controlMapper = m_ControlMapper.value as ControlMapper;

			if (controlMapper == null)
			{
				return;
			}

			controlMapper.Close(m_SaveOnClose.value);
		}
	}
}