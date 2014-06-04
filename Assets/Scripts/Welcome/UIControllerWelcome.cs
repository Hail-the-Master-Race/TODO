using UnityEngine;
using System.Collections;

public class UIControllerWelcome : MonoBehaviour
{

    public void OnClickNewGame ()
    {
        Application.LoadLevel ("CharacterCreateScene");
    }

	public void OnClickPlayOnline () {
		Debug.Log ("Loading ServerListScene");
		Application.LoadLevel ("ServerListScene");
	}

    public void OnClickHighScore ()
    { 
        Application.LoadLevel ("HighScoreAchievementsScene");
    }

    public void OnClickSettings ()
    {
        Application.LoadLevel ("SettingScene");
    }
}
