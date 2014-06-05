using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PlayerStats stats;
	public PlayerCollisions collisions;
	public PlayerController controller;

	public Level levelGen;

	public Transform playerPrefab;
	
	// add initialization logic here
	
	void Awake() {

	}
	

	public void Spawn() {
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();

		if (!playerPrefab)
			return;

		Vector3 playerSpawnLocation = levelGen.GetRandomRoom().getCenterSpawnPoint();

		GameObject.Instantiate (playerPrefab, playerSpawnLocation, Quaternion.identity);	
	}
}
