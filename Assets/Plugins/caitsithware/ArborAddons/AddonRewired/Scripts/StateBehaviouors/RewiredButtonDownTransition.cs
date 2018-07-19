using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("caitsithware/Rewired/RewiredButtonDownTransition")]
	[AddComponentMenu("")]
	public class RewiredButtonDownTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleBool m_IsSystemPlayer = new FlexibleBool(false);

		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private StateLink m_OnButtonDown = new StateLink();

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

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (m_Player != null && !string.IsNullOrEmpty(m_CachedActionName) && m_Player.GetButtonDown(m_CachedActionName))
			{
				Transition(m_OnButtonDown);
			}
		}
	}
}