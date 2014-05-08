using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Colliding");
		if(other.gameObject.CompareTag("Player")) {
			PlayerController player = other.gameObject.transform.root.GetComponent<PlayerController>();
			//if(player.attacking) 
				Destroy(this.gameObject);
		}
	}
}
