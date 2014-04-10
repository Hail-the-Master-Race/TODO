using UnityEngine;
using System.Collections;

public class welcomeUI : MonoBehaviour
{
		void OnGUI ()
		{
				GUILayout.Label ("TODO: Dungeon of Doom, Obviously");

				if (GUILayout.Button ("New Game")) {
						Application.LoadLevel ("StartScene");
				}

				if (GUILayout.Button ("Continue")) {
						Debug.Log ("TODO: continue game");
				}

				if (GUILayout.Button ("Settings")) {
						Application.LoadLevel ("SettingScene");
				}

				if (GUILayout.Button ("High Score\nand\nAchievements")) {
						Debug.Log ("TODO: high score and achievements");
				}

		}
}