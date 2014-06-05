using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	public GameObject playerPrefab;
	public Transform spawnObject;

	// Janky janky janky...
	private bool isPaused = false;
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

	void UpdateIsPasued () {
		isPaused = !isPaused;
		// Stop time when paused
//		Time.timeScale = isPaused ? 0 : 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			UpdateIsPasued();

			if (refreshing) {
				if (MasterServer.PollHostList ().Length > 0) {
					refreshing = false;
					Debug.Log (MasterServer.PollHostList ().Length);
					hostData = MasterServer.PollHostList ();
				}
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
		// I'm guessing we're using the same model for all players, and only need to send over
		// stat data etc.
		Network.Instantiate (playerPrefab, spawnObject.position, Quaternion.identity, 0);
	}
	
	void OnServerInitialized () {
		Debug.Log ("Server Initialized");
		// Local player shouldn't require a server to play on
		// spawnPlayer ();
	}

	void OnConnectedToServer () {
		Debug.Log ("Connected to server");
		// Spawn new player...
		spawnPlayer ();
	}
	
	void OnMasterServerEvent (MasterServerEvent mse) {
		if (mse == MasterServerEvent.RegistrationSucceeded) {
			Debug.Log ("Registered Server");
		}
	}


// GUI
// -- This will need to be changed to use NGUI and only appear on pause menu
// -- Shouldn't be that hard...
	void OnGUI () {	
		if (isPaused) {
			if (!Network.isClient && !Network.isServer) {
				if (GUI.Button (new Rect (btnX, btnY, btnW, btnH), "Start Server")) {
					Debug.Log ("Starting server");
					startServer ();
					UpdateIsPasued();
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
}
