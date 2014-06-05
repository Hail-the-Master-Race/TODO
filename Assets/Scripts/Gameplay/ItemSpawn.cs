using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {
	
	public int numItemsBase = 20;
	private int numItemsOffset = 10; // TODO
	private string[] types;

	private Level levelGen;
	
	public Transform Prefab;
	
	void Awake()
	{
		types = new string[3];
		types[0] = "health";
		types [1] = "magic";
		types [2] = "food";
	}
	
	public void LateStart()
	{
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();	
		GenerateItems ();
	}
	
	void GenerateItems()
	{
		numItemsBase = Mathf.FloorToInt(Random.Range (numItemsBase, numItemsBase + numItemsOffset));

		for (int i = 0; i < numItemsBase; i++) {
			GenerateItem ();
			Debug.Log("generating item");
		}
	}
	
	void GenerateItem()
	{
		int newType = Mathf.FloorToInt(Random.Range(0, 3));

		Room spawnRoom = levelGen.GetRandomRoom ();
		
		if (spawnRoom == null)
			return;
		
		Vector3 SpawnLocation = spawnRoom.getCenterSpawnPoint();
		
		Transform newItem = (Transform) GameObject.Instantiate (Prefab, SpawnLocation, Quaternion.identity);
		newItem.rotation = Quaternion.Euler (45, 45, 45);
		newItem.gameObject.GetComponent<PickUp>().type = types[newType];
	}
}
