using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PlayerStats stats;
	public PlayerCollisions collisions;
	public PlayerController controller;

	public Transform playerPrefab;
	
	// add initialization logic here
	
	public void Start() {
		Init ();
	}
	
	public void Init() {
		if (playerPrefab) {
			GameObject.Instantiate (playerPrefab, new Vector3 (1, 1, 0), Quaternion.identity);
		}
	}
}
