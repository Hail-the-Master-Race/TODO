using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	private NetworkManagerScript networkManager;

	// Use this for initialization
	void Start () {
		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if(this.gameObject.CompareTag("Enemy")) damagePlayer (other);
		else damageEnemy (other);
	}

	void damageEnemy(Collider other) {
		Debug.Log ("Player Collision");
		if (other.gameObject.CompareTag ("Enemy")) {
			Enemy enemy = other.gameObject.transform.root.GetComponent<Enemy> ();
			Debug.Log(enemy);
			Player player = this.gameObject.transform.root.GetComponent<Player> ();
			enemy.stats.currentHP -= player.stats.STR;
			Debug.Log(enemy.stats.currentHP);
			Debug.Log(player.stats.STR);
		}

	}

	void damagePlayer(Collider other) {
		Debug.Log ("Enemy Collision");
		if (other.gameObject.CompareTag (networkManager.playerTag)) {
			Player player = (Player)other.gameObject.transform.root.GetComponent<Player> ();
			Enemy enemy = (Enemy)this.gameObject.transform.root.GetComponent<Enemy> ();
			player.stats.currentHP -= enemy.stats.damage;
		}
	}
}
