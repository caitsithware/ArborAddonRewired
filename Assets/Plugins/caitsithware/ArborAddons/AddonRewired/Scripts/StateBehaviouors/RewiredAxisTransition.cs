using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("caitsithware/Rewired/RewiredAxisTransition")]
	[AddComponentMenu("")]
	public class RewiredAxisTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleBool m_IsSystemPlayer = new FlexibleBool(false);

		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private OutputSlotFloat m_OutputAxisValue = new OutputSlotFloat();

		[SerializeField]
		private StateLink m_OnAxis = new StateLink();

		private Player m_Player;

		private string m_CachedActionName;
		
		// Use this for enter state
		public override void OnStateBegin()
		{
			if (m_IsSystemPlayer.value)
			{
				m_Player = ReInput.players.GetSystemPlayer();
			}
			else
			{
				m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
			}

			m_CachedActionName = (m_Player != null) ? m_ActionName.value : "";
		}

		void CheckTransition()
		{
			if (m_Player == null || string.IsNullOrEmpty(m_CachedActionName))
			{
				return;
			}

			float axisValue = m_Player.GetAxis(m_CachedActionName);
			if (axisValue != 0.0f)
			{
				m_OutputAxisValue.SetValue(axisValue);
				Transition(m_OnAxis);
			}
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			CheckTransition();
		}
	}
}