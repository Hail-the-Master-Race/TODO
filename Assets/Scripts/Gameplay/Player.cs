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
	

	public void Spawn(int num) {
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();

		if (!playerPrefab)
			return;

		Vector3 playerSpawnLocation = levelGen.GetRandomRoom().getCenterSpawnPoint();

		Transform player = (Transform)GameObject.Instantiate (playerPrefab, playerSpawnLocation, Quaternion.identity);
		player.tag = "Player" + num.ToString();

		// TODO: insure against empty/non-existent packet object
		Character PCPacket = GameObject.Find ("PC Packet").GetComponent<Character> ();
	
		PlayerStats PCStat = GameObject.FindGameObjectWithTag (player.tag)
			.GetComponent<PlayerStats> ();
		
		PCStat.Init (PCPacket);
	}
}
