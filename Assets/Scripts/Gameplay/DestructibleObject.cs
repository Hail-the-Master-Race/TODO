using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {
	private NetworkManagerScript networkManager;
	
	public int stamina;

	void Start () {
		networkManager = GameObject.Find ("NetworkManager").GetComponent<NetworkManagerScript> ();
	}

	void DestroyObject (Collider other) {
		Debug.Log ("Destroying object");
		if(other.gameObject.CompareTag(networkManager.playerTag)) {
			Player player = other.gameObject.transform.root.GetComponent<Player>();
			//if(player.attacking) 
			stamina -= 10;
			Debug.Log(stamina);
			if(stamina == 0)
				Network.Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Colliding");
		DestroyObject (other);
	}
}
