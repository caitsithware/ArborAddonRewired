using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/RewiredButtonUpTransition")]
	[AddComponentMenu("")]
	public class RewiredButtonUpTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleBool m_IsSystemPlayer = new FlexibleBool(false);

		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButtonUp= new StateLink();

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

		bool CheckTransition()
		{
			if (m_Player == null || string.IsNullOrEmpty(m_CachedActionName))
			{
				return false;
			}

			switch (m_AxisContribution)
			{
				case AxisContributionType.Any:
					return m_Player.GetButtonUp(m_CachedActionName) || m_Player.GetNegativeButtonUp(m_CachedActionName);
				case AxisContributionType.Positive:
					return m_Player.GetButtonUp(m_CachedActionName);
				case AxisContributionType.Negative:
					return m_Player.GetNegativeButtonUp(m_CachedActionName);
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (CheckTransition())
			{
				Transition(m_OnButtonUp);
			}
		}
	}
}