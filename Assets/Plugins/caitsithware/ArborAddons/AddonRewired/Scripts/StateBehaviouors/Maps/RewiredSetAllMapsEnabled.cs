using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Maps/RewiredSetAllMapsEnabled")]
	[AddComponentMenu("")]
	public class RewiredSetAllMapsEnabled : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleBool m_State = new FlexibleBool(false);

		[SerializeField]
		private SetMapsEnabledControllerFlags m_ControllerFlags = RewiredUtility.AllControllerFlags;

		// Use this for enter state
		public override void OnStateBegin()
		{
			Player player = ReInput.players.GetPlayer(m_PlayerName.value);

			if (player == null)
			{
				return;
			}

			if ((m_ControllerFlags & RewiredUtility.AllControllerFlags) == RewiredUtility.AllControllerFlags)
			{
				player.controllers.maps.SetAllMapsEnabled(m_State.value);
			}
			else
			{
				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Keyboard) == SetMapsEnabledControllerFlags.Keyboard)
				{
					player.controllers.maps.SetAllMapsEnabled(m_State.value, ControllerType.Keyboard);
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Mouse) == SetMapsEnabledControllerFlags.Mouse)
				{
					player.controllers.maps.SetAllMapsEnabled(m_State.value, ControllerType.Joystick);
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Joystick) == SetMapsEnabledControllerFlags.Joystick)
				{
					player.controllers.maps.SetAllMapsEnabled(m_State.value, ControllerType.Joystick);
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Custom) == SetMapsEnabledControllerFlags.Custom)
				{
					player.controllers.maps.SetAllMapsEnabled(m_State.value, ControllerType.Custom);
				}
			}
		}
	}
}
