using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Enemy Collision");
		if (other.gameObject.CompareTag ("Player")) {
			Player player = other.gameObject.transform.root.GetComponent<Player> ();
			EnemyStats enemyStats = this.gameObject.transform.root.GetComponent<EnemyStats> ();

			player.stats.currentHP -= enemyStats.damage;
		}
	}
}
