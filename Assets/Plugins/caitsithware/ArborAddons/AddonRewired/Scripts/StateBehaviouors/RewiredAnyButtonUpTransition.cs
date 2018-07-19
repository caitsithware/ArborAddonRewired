using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("caitsithware/Rewired/RewiredAnyButtonUpTransition")]
	[AddComponentMenu("")]
	public class RewiredAnyButtonUpTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleBool m_IsSystemPlayer = new FlexibleBool(false);

		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButtonUp = new StateLink();

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

		bool CheckTransition()
		{
			if (m_Player == null)
			{
				return false;
			}

			switch (m_AxisContribution)
			{
				case AxisContributionType.Any:
					return m_Player.GetAnyButtonUp() || m_Player.GetAnyNegativeButtonUp();
				case AxisContributionType.Positive:
					return m_Player.GetAnyButtonUp();
				case AxisContributionType.Negative:
					return m_Player.GetAnyNegativeButtonUp();
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if ( CheckTransition() )
			{
				Transition(m_OnButtonUp);
			}
		}
	}
}