using UnityEngine;
using System.Collections;

public class welcomeUI : MonoBehaviour
{
		void OnGUI ()
		{
				GUILayout.Label ("TODO: Dungeon of Doom, Obviously");

				if (GUILayout.Button ("New Game")) {
						Debug.Log ("TODO: begin new game");
				}

				if (GUILayout.Button ("Continue")) {
						Debug.Log ("TODO: continue game");
				}

				if (GUILayout.Button ("Settings")) {
						Debug.Log ("TODO: settings");
				}

				if (GUILayout.Button ("High Score\nand\nAchievements")) {
						Debug.Log ("TODO: high score and achievements");
				}

		}
}