using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {
	public int stamina;
	
	void DestroyObject (Collider other) {
		Debug.Log ("Destroying object");
		if(other.gameObject.CompareTag("Player")) {
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
