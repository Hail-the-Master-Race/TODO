using UnityEngine;
using System.Collections;

public class NetworkManagerScript : MonoBehaviour {
	private UIScript ui;
	private Player player;

	// Janky janky janky...
	public bool isOnline = false; 
	private bool isPaused = false;
	private bool refreshing;
	public HostData[] hostData = null;

	// Start Server Button
	private float btnX;
	private float btnY;
	private float btnW;
	private float btnH;
	public string gameName = "UChicago_GameConstruction_TODO";
	
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
	public void startServer () {
		Network.InitializeServer (4, 25001, !Network.HavePublicAddress());

		// Register game to Unity Master server
		// -- In theory, we could set up our own server, 
		// -- but for now, this will make things a bit easier...
		MasterServer.RegisterHost (gameName, "TODO", "Temple of Doom, Obviously");
	}

	// Refresh Host List
	public void refreshHostList () {
		MasterServer.RequestHostList (gameName);
		refreshing = true;
	}

	void OnServerInitialized () {
		Debug.Log ("Server Initialized");
		GameObject.FindWithTag ("Player").tag = "Player1";

		isOnline = true;
	}

	void OnConnectedToServer () {
		Debug.Log ("Connected to server...");
		Debug.Log ("Spawning your character...");
		isOnline = true;
		// Spawn new player...
		player = GameObject.Find ("PlayerSpawn").GetComponent<Player> ();
		player.Spawn (2);
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
		ui = GameObject.Find ("Game Controller").GetComponent<UIScript> ();
		if (ui.isPaused) {
			if (!Network.isClient && !Network.isServer) {
				if (GUI.Button (new Rect (btnX, btnY, btnW, btnH), "Start Server")) {
					Debug.Log ("Starting server");
					startServer ();
					ui.UpdateIsPasued();
				}	
				/*
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
				*/
			}
		}
	}
}
