using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace caitsithware.ArborAddons.AddonRewired.Examples
{
	using Rewired;

	[RequireComponent(typeof(Text))]
	public class RewiredMapsDebugText : MonoBehaviour
	{
		[SerializeField]
		private string m_PlayerName = "Player0";

		private Player m_Player;
		private Text m_Text;
		private System.Text.StringBuilder m_StringBuilder = new System.Text.StringBuilder();

		// Use this for initialization
		void Start()
		{
			m_Player = ReInput.players.GetPlayer(m_PlayerName);

			m_Text = GetComponent<Text>();

			UpdateText();
		}

		void UpdateText()
		{
			if (m_Player == null)
			{
				return;
			}

			m_StringBuilder.Length = 0;

			foreach (ControllerType type in System.Enum.GetValues(typeof(ControllerType)))
			{
				List<ControllerMap> maps = new List<ControllerMap>();
				m_Player.controllers.maps.GetAllMaps(type,maps);
				if (maps.Count > 0)
				{
					m_StringBuilder.AppendFormat("{0} ({1})\n", type, maps.Count);

					foreach (ControllerMap map in maps)
					{
						InputMapCategory category = ReInput.mapping.GetMapCategory(map.categoryId);
						InputLayout layout = ReInput.mapping.GetLayout(type, map.layoutId);
						m_StringBuilder.AppendFormat("  {0} {1}\t {2}\n", category.name, layout.name, map.enabled ? "Enable" : "Disable");
					}

					m_StringBuilder.AppendLine();
				}
			}

			m_Text.text = m_StringBuilder.ToString();
		}

		// Update is called once per frame
		void Update()
		{
			UpdateText();
		}
	}
}
