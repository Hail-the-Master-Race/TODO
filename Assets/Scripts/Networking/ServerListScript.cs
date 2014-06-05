using UnityEngine;
using System.Collections;

public class ServerListScript : MonoBehaviour {
	private bool refreshing;
	private HostData[] hostData = null;
	private string gameName = "UChicago_GameConstruction_TODO";
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;

	// Use this for initialization
	void Start () {
		btnX = Screen.width  * (float) 0.2;
		btnY = Screen.height * (float) 0.2;
		btnW = Screen.width  * (float) 0.15;
		btnH = Screen.width  * (float) 0.15;
	}
	
	// Update is called once per frame
	void Update () {
		if (refreshing) {
			if (MasterServer.PollHostList ().Length > 0) {
				refreshing = false;
				Debug.Log (MasterServer.PollHostList ().Length);
				hostData = MasterServer.PollHostList ();
			}
		}
	}

	// Refresh Host List
	void refreshHostList () {
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	}

	public void OnClickRefreshHostList () {
		Debug.Log ("Refreshing host list...");
		refreshHostList ();
	}

	void OnGUI () {
		if (hostData != null) {
			for (int i = 0; i < hostData.Length; ++i) {
				if (GUI.Button (new Rect (
					btnX * (float)1 + btnW, 
					btnY * (float)3.5 + (btnH * i),
					btnW * (float)3,
					btnH * (float)0.25),
	                hostData [i].gameName)) {
						Network.Connect (hostData [i]);
						Application.LoadLevel ("StartScene");
				}
			}
		}
	}
}
