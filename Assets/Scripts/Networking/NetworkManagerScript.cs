using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	public GameObject playerPrefab;
	public Transform spawnObject;

	private bool refreshing;
	private HostData[] hostData = null;

	// Start Server Button
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;
	private string gameName = "UChicago_GameConstruction_TODO";
	
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

	// Start Server
	void startServer () {
		Network.InitializeServer (4, 25001, !Network.HavePublicAddress());
		
		// Register game to Unity Master server
		// -- In theory, we could set up our own server, 
		// -- but for now, this will make things a bit easier...
		MasterServer.RegisterHost (gameName, "TODO", "Temple of Doom, Obviously");
	}

	// Refresh Host List
	void refreshHostList () {
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	}

	void spawnPlayer () {
		Network.Instantiate (playerPrefab, spawnObject.position, Quaternion.identity, 0);
	}
	
	void OnServerInitialized () {
		Debug.Log ("Server Initialized");
		spawnPlayer ();
	}

	void OnConnectedToServer () {
		Debug.Log ("Connected to server");
		spawnPlayer ();
	}
	
	void OnMasterServerEvent (MasterServerEvent mse) {
		if (mse == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Registered Server");
		}
	}


// GUI
// -- This will need to be changed to use NGUI and only appear on pause menu
	void OnGUI () {	
		if (!Network.isClient && !Network.isServer) {
			if (GUI.Button (new Rect (btnX, btnY, btnW, btnH), "Start Server")) {
				Debug.Log ("Starting server");
				startServer ();
			}	

			if (GUI.Button (new Rect (btnX, btnY * (float)2.5, btnW, btnH), "Refresh Hosts")) {
				Debug.Log ("Refreshing hosts list");
				refreshHostList ();
			}
			if (hostData != null) {
				for (int i = 0; i < hostData.Length; ++i) {
					if (GUI.Button (new Rect (
						btnX * (float)1.5 + btnW, 
	     				btnY * (float)2.5 + (btnH * i),
	     				btnW * (float)3,
	     				btnH * (float)0.25),
						hostData [i].gameName)) {
							Network.Connect (hostData [i]);
					}
				}
			}
		}
	}
}
