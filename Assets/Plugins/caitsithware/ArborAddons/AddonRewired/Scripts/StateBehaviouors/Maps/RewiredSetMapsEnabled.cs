using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace caitsithware.ArborAddons.AddonRewired.StateBehaviours
{
	using Arbor;
	using Rewired;

	[AddBehaviourMenu("Rewired/Maps/RewiredSetMapsEnabled")]
	[AddComponentMenu("")]
	public class RewiredSetMapsEnabled : StateBehaviour
	{
		[SerializeField]
		private FlexibleString m_PlayerName = new FlexibleString("Player0");

		[SerializeField]
		private FlexibleString m_CategoryName = new FlexibleString("Default");

		[SerializeField]
		private FlexibleString m_LayoutName = new FlexibleString("");

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

			string categoryName = m_CategoryName.value;

			if (string.IsNullOrEmpty(categoryName))
			{
				return;
			}

			string layoutName = m_LayoutName.value;

			bool hasLayoutName = !string.IsNullOrEmpty(layoutName);

			if ((m_ControllerFlags & RewiredUtility.AllControllerFlags) == RewiredUtility.AllControllerFlags)
			{
				if (hasLayoutName)
				{
					player.controllers.maps.SetMapsEnabled(m_State.value, categoryName, layoutName);
				}
				else
				{
					player.controllers.maps.SetMapsEnabled(m_State.value, categoryName);
				}
			}
			else
			{
				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Keyboard) == SetMapsEnabledControllerFlags.Keyboard)
				{
					if (hasLayoutName)
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Keyboard, categoryName, layoutName);
					}
					else
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Keyboard, categoryName);
					}
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Mouse) == SetMapsEnabledControllerFlags.Mouse)
				{
					if (hasLayoutName)
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Mouse, categoryName, layoutName);
					}
					else
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Mouse, categoryName);
					}
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Joystick) == SetMapsEnabledControllerFlags.Joystick)
				{
					if (hasLayoutName)
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Joystick, categoryName, layoutName);
					}
					else
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Joystick, categoryName );
					}
				}

				if ((m_ControllerFlags & SetMapsEnabledControllerFlags.Custom) == SetMapsEnabledControllerFlags.Custom)
				{
					if (hasLayoutName)
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Custom, categoryName, layoutName);
					}
					else
					{
						player.controllers.maps.SetMapsEnabled(m_State.value, ControllerType.Custom, categoryName);
					}
				}
			}
		}
	}
}
