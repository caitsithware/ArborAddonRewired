using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Transition/RewiredButtonTimedPressUpTransition")]
	[AddComponentMenu("")]
	public class RewiredButtonTimedPressUpTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private FlexibleFloat m_Time = new FlexibleFloat(0f);

		[SerializeField]
		private FlexibleFloat m_ExpireIn = new FlexibleFloat(0f);

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButtonTimedPressUp = new StateLink();

		private Player m_Player;
		private string m_CachedActionName;
		private float m_CachedTime;
		private float m_CachedExpireIn;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
			if (m_Player != null)
			{
				m_CachedActionName = m_ActionName.value;
				m_CachedTime = m_Time.value;
				m_CachedExpireIn = m_ExpireIn.value;
			}
			else
			{
				m_CachedActionName = "";
				m_CachedTime = 0f;
				m_CachedExpireIn = 0f;
			}
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
					return m_Player.GetButtonTimedPressUp(m_CachedActionName, m_CachedTime, m_CachedExpireIn) || m_Player.GetNegativeButtonTimedPressUp(m_CachedActionName, m_CachedTime, m_CachedExpireIn);
				case AxisContributionType.Positive:
					return m_Player.GetButtonTimedPressUp(m_CachedActionName, m_CachedTime, m_CachedExpireIn);
				case AxisContributionType.Negative:
					return m_Player.GetNegativeButtonTimedPressUp(m_CachedActionName, m_CachedTime, m_CachedExpireIn);
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (CheckTransition())
			{
				Transition(m_OnButtonTimedPressUp);
			}
		}
	}
}