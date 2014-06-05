using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private NetworkManagerScript networkManager;

	public PlayerStats stats;
	public PlayerCollisions collisions;
	public PlayerController controller;

	public Transform playerPrefab;
	
	// add initialization logic here
	void Start () {
//		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();
	}
	
	void Awake() {
		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();
		Init ();
	}
	
	private void Init() {
		spawnPlayer (new Vector3 (1, 1, 0));
	}

	public void spawnPlayer (Vector3 spawnPoint) {
		if (playerPrefab) {
			if (networkManager.isOnline)
				Network.Instantiate (playerPrefab, spawnPoint, Quaternion.identity, 1);
			else
				GameObject.Instantiate (playerPrefab, spawnPoint, Quaternion.identity);
		}
	}
}
