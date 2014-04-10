using UnityEngine;
using System.Collections;

public class WelcomeUI : MonoBehaviour
{
		void OnGUI ()
		{
		GUILayout.Label ("TODO: Dungeon of Doom, Obviously");
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 300));

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
		GUILayout.EndArea ();

		}
}