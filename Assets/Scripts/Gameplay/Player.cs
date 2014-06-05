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
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();
	}

	void Start() {
		Init ();
	}
	
	private void Init() {
		if (!playerPrefab)
			return;

		Vector3 playerSpawnLocation = levelGen.roomsList[10].getCenterSpawnPoint();

		GameObject.Instantiate (playerPrefab, playerSpawnLocation, Quaternion.identity);	
	}
}
