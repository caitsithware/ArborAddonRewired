﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Transition/RewiredButtonDoublePressHoldTransition")]
	[AddComponentMenu("")]
	public class RewiredButtonDoublePressHoldTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_ActionName = new FlexibleString("");

		[SerializeField]
		private FlexibleFloat m_Speed = new FlexibleFloat(0f);

		[SerializeField]
		private AxisContributionType m_AxisContribution = AxisContributionType.Any;

		[SerializeField]
		private StateLink m_OnButtonDoublePressHold = new StateLink();

		private Player m_Player;

		private string m_CachedActionName;

		private float m_CachedSpeed;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
			m_CachedActionName = m_ActionName.value;
			m_CachedSpeed = m_Speed.value;
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
					return m_Player.GetButtonDoublePressHold(m_CachedActionName, m_CachedSpeed) || m_Player.GetNegativeButtonDoublePressHold(m_CachedActionName, m_CachedSpeed);
				case AxisContributionType.Positive:
					return m_Player.GetButtonDoublePressHold(m_CachedActionName, m_CachedSpeed);
				case AxisContributionType.Negative:
					return m_Player.GetNegativeButtonDoublePressHold(m_CachedActionName, m_CachedSpeed);
			}

			return false;
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			if (CheckTransition())
			{
				Transition(m_OnButtonDoublePressHold);
			}
		}
	}
}