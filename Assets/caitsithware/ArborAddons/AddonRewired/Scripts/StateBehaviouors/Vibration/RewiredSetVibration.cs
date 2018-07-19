using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Vibration/RewiredSetVibration")]
	[AddComponentMenu("")]
	public class RewiredSetVibration : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		[ConstantRange(0f,1f)]
		private FlexibleFloat m_MotorLevel = new FlexibleFloat(1.0f);

		[SerializeField]
		private FlexibleBool m_IsSetDuration = new FlexibleBool(true);

		[SerializeField]
		private FlexibleFloat m_Duration = new FlexibleFloat(1f);

		[SerializeField]
		private FlexibleBool m_StopOnEnd = new FlexibleBool(true);

		private Player m_Player;

		private bool m_CachedStopOnEnd;

		// Use this for enter state
		public override void OnStateBegin()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName.value);

			if (m_Player == null)
			{
				return;
			}

			float motorLevel = m_MotorLevel.value;
			float duration = m_Duration.value;
			bool isSetDuration = m_IsSetDuration.value;
			m_CachedStopOnEnd = m_StopOnEnd.value;

			foreach (var joystick in m_Player.controllers.Joysticks)
			{
				if (!joystick.enabled || !joystick.supportsVibration)
				{
					continue;
				}

				if (isSetDuration)
				{
					joystick.SetVibration(motorLevel, motorLevel, duration, duration);
				}
				else
				{
					joystick.SetVibration(motorLevel, motorLevel);
				}
			}
		}

		// Use this for exit state
		public override void OnStateEnd()
		{
			if (m_CachedStopOnEnd)
			{
				foreach (var joystick in m_Player.controllers.Joysticks)
				{
					if (!joystick.enabled || !joystick.supportsVibration)
					{
						continue;
					}

					joystick.StopVibration();
				}
			}
		}
	}
}