using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arbor;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Transition/RewiredAxis2DTransition")]
	[AddComponentMenu("")]
	public class RewiredAxis2DTransition : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_XAxisActionName = new FlexibleString("Move Horizontal");

		[SerializeField]
		private FlexibleString m_YAxisActionName = new FlexibleString("Move Vertical");

		[SerializeField]
		private OutputSlotVector2 m_OutputAxisValue = new OutputSlotVector2();

		[SerializeField]
		private StateLink m_OnAxis2D = new StateLink();

		private Player m_Player;

		private string m_CachedXAxisActionName;
		private string m_CachedYAxisActionName;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);
			
			m_CachedXAxisActionName = m_XAxisActionName.value;
			m_CachedYAxisActionName = m_YAxisActionName.value;
		}

		void CheckTransition()
		{
			if (m_Player == null || string.IsNullOrEmpty(m_CachedXAxisActionName) || string.IsNullOrEmpty(m_CachedYAxisActionName))
			{
				return;
			}

			Vector2 axisValue = m_Player.GetAxis2D(m_CachedXAxisActionName,m_CachedYAxisActionName);
			if (axisValue.sqrMagnitude != 0.0f)
			{
				m_OutputAxisValue.SetValue(axisValue);
				Transition(m_OnAxis2D);
			}
		}

		// OnStateUpdate is called once per frame
		public override void OnStateUpdate()
		{
			CheckTransition();
		}
	}
}