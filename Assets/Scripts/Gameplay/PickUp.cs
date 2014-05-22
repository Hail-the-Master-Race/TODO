using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	public string type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag(Tags.player)) {
			PlayerStats stats = other.GetComponent<PlayerStats>();

			switch(type) {
				case "health": 
					stats.currentHP += 10;
					if(stats.currentHP > stats.MaxHP) stats.currentHP = stats.MaxHP;
					break;
				case "magic": break;
				case "food": 
					stats.currentHunger += 10;
					if(stats.currentHP > stats.MaxHunger) stats.currentHunger = stats.MaxHunger;
				break;
			}
			Destroy (this.gameObject);
		}
	}
}
