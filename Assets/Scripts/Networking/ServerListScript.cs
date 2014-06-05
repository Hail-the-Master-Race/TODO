using UnityEngine;
using System.Collections;

public class ServerListScript : MonoBehaviour {
	private NetworkManagerScript networkManager;
	private bool showHostList;
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (GameObject.Find ("NetworkManager"));
		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();

		showHostList = true;
		btnX = Screen.width  * (float) 0.2;
		btnY = Screen.height * (float) 0.2;
		btnW = Screen.width  * (float) 0.15;
		btnH = Screen.width  * (float) 0.15;
	}


	public void OnClickCreateServer () {
		networkManager.startServer ();
		Application.LoadLevel ("StartScene");
	}

	public void OnClickRefreshHostList () {
		Debug.Log ("Refreshing host list...");
		networkManager.refreshHostList ();
	}

	void OnGUI () {
		if (networkManager.hostData != null && showHostList) {
			for (int i = 0; i < networkManager.hostData.Length; ++i) {
				if (GUI.Button (new Rect (
					btnX * (float)1 + btnW, 
					btnY * (float)3.5 + (btnH * i),
					btnW * (float)3,
					btnH * (float)0.25),
	                networkManager.hostData [i].gameName)) {
					showHostList = false;
					networkManager.setHostIdx(i);
					Application.LoadLevel ("CharacterCreateScene");

//					Network.Connect (networkManager.hostData[networkManager.getHostIdx()]);
//					Application.LoadLevel ("StartScene");
				}
			}
		}
	}
}
