using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private NetworkManagerScript networkManager;

	public PlayerStats stats;
	public PlayerCollisions collisions;
	public PlayerController controller;

	public Level levelGen;

	public Transform playerPrefab;
	
	// add initialization logic here
	void Start () {

	}
	
	void Awake() {
		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();
	}
	

	public void Spawn() {
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();

		if (!playerPrefab)
			return;

		Vector3 playerSpawnLocation = levelGen.GetRandomRoom().getCenterSpawnPoint();

		if (networkManager.isOnline)
			Network.Instantiate (playerPrefab, playerSpawnLocation, Quaternion.identity, 1);
		else
			GameObject.Instantiate (playerPrefab, playerSpawnLocation, Quaternion.identity);	
	}
}
