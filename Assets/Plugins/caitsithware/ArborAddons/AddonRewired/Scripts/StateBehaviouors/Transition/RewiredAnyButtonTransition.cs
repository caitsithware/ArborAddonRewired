using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/RewiredAnyButtonTransition")]
	[AddComponentMenu("")]
	public class RewiredAnyButtonTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButton = new StateLink();

		private Player m_Player;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
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
					return m_Player.GetAnyButton() || m_Player.GetAnyNegativeButton();
				case AxisContributionType.Positive:
					return m_Player.GetAnyButton();
				case AxisContributionType.Negative:
					return m_Player.GetAnyNegativeButton();
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (CheckTransition())
			{
				Transition(m_OnButton);
			}
		}
	}
}