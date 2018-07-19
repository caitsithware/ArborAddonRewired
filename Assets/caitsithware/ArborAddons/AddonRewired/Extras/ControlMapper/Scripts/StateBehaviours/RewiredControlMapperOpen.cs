	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired
{
	using Arbor;
	using Rewired.UI.ControlMapper;

	[AddBehaviourMenu("Rewired/ControlMapper/RewiredControlMapperOpen")]
	[AddComponentMenu("")]
	public class RewiredControlMapperOpen : StateBehaviour
	{
		[ClassExtends(typeof(ControlMapper))]
		[SerializeField]
		private FlexibleComponent m_ControlMapper = new FlexibleComponent();

		[SerializeField]
		private FlexibleBool m_CloseOnEnd = new FlexibleBool(false);

		[SerializeField]
		private FlexibleBool m_SaveOnEnd = new FlexibleBool(false);

		[SerializeField]
		private StateLink m_OnScreenClosed = new StateLink();

		private ControlMapper m_CachedControlMapper;
		private bool m_CachedCloseOnEnd;
		private bool m_CachedSaveOnEnd;

		private bool m_AddedListerOnScreenClosed = false;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_CachedControlMapper = m_ControlMapper.value as ControlMapper;

			if (m_CachedControlMapper == null)
			{
				return;
			}

			m_CachedCloseOnEnd = m_CloseOnEnd.value;
			m_CachedSaveOnEnd = m_SaveOnEnd.value;

			m_CachedControlMapper.Open();

			m_CachedControlMapper.onScreenClosed += OnScreenClosed;
			m_AddedListerOnScreenClosed = true;
		}

		void RemoveListerOnScreeClosed()
		{
			if (m_AddedListerOnScreenClosed)
			{
				m_CachedControlMapper.onScreenClosed -= OnScreenClosed;
				m_AddedListerOnScreenClosed = false;
			}
		}

		public override void OnStateEnd()
		{
			if (m_CachedControlMapper == null)
			{
				return;
			}

			if (m_CachedCloseOnEnd)
			{
				m_CachedControlMapper.Close(m_CachedSaveOnEnd);
			}

			RemoveListerOnScreeClosed();
		}

		void OnScreenClosed()
		{
			RemoveListerOnScreeClosed();

			Transition(m_OnScreenClosed);
		}

		private void OnDestroy()
		{
			RemoveListerOnScreeClosed();
		}
	}
}