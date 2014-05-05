using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Debug.Log ("Colliding");
		//if(other.gameObject.CompareTag("Player")) {
			PlayerController player = hit.controller.gameObject.GetComponent<PlayerController>();
			//if(player.attacking) 
			Destroy(this);
		//}
	}
}
