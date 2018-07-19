using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace caitsithware.ArborAddons.AddonRewired
{
	[System.Flags]
	public enum SetMapsEnabledControllerFlags
	{
		Keyboard	= 0x0001,
		Mouse		= 0x0002,
		Joystick	= 0x0004,
		Custom		= 0x8000,
	}
}
