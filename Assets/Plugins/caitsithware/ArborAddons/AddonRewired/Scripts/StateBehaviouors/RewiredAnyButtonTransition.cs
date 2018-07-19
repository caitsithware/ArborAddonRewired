using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("caitsithware/Rewired/RewiredAnyButtonTransition")]
	[AddComponentMenu("")]
	public class RewiredAnyButtonTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleBool m_IsSystemPlayer = new FlexibleBool(false);

		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private StateLink m_OnButton = new StateLink();

		private Player m_Player;

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
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (m_Player != null && m_Player.GetAnyButton())
			{
				Transition(m_OnButton);
			}
		}
	}
}