using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {
	public GameObject playerPrefab;
	public Transform spawnObject;
	
	void spawnPlayer () {
		Network.Instantiate (playerPrefab, spawnObject.position, Quaternion.identity, 0);
	}
}
