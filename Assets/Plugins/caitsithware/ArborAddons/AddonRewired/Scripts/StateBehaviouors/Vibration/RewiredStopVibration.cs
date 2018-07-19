using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Vibration/RewiredStopVibration")]
	[AddComponentMenu("")]
	public class RewiredStopVibration : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		// Use this for enter state
		public override void OnStateBegin()
		{
			Player player = ReInput.players.GetPlayer(m_PlayerName.value);

			if (player == null)
			{
				return;
			}

			foreach (var joystick in player.controllers.Joysticks)
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