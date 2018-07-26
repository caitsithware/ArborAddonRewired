using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Transition/RewiredButtonSinglePressHoldTransition")]
	[AddComponentMenu("")]
	public class RewiredButtonSinglePressHoldTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButtonSinglePressHold = new StateLink();

		private Player m_Player;

		private string m_CachedActionName;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
			m_CachedActionName = (m_Player != null) ? m_ActionName.value : "";
		}

		bool CheckTransition()
		{
			if (m_Player == null || string.IsNullOrEmpty(m_CachedActionName))
			{
				return false;
			}

			switch (m_AxisContribution)
			{
				case AxisContributionType.Any:
					return m_Player.GetButtonSinglePressHold(m_CachedActionName) || m_Player.GetNegativeButtonSinglePressHold(m_CachedActionName);
				case AxisContributionType.Positive:
					return m_Player.GetButtonSinglePressHold(m_CachedActionName);
				case AxisContributionType.Negative:
					return m_Player.GetNegativeButtonSinglePressHold(m_CachedActionName);
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (CheckTransition())
			{
				Transition(m_OnButtonSinglePressHold);
			}
		}
	}
}