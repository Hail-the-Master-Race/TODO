using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour {

	public int stamina;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Colliding");
		if(other.gameObject.CompareTag("Player")) {
			Player player = other.gameObject.transform.root.GetComponent<Player>();
			//if(player.attacking) 
				stamina -= 10;
			Debug.Log(stamina);
			if(stamina == 0)
				Destroy(this.gameObject);
		}
	}
}
