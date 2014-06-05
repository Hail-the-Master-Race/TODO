using UnityEngine;
using System.Collections;

public class EnemyGenerate : MonoBehaviour {

	public int numMobsBase = 5;
	private int numMobsOffset = 1; // TODO

	private Level levelGen;

	public Transform Prefab;

	void Awake()
	{
	}

	public void LateStart()
	{
		levelGen = GameObject.FindGameObjectWithTag (Tags.levelGen).GetComponent<Level>();	
		GenerateEnemies ();
	}

	void GenerateEnemies()
	{
		for (int i = 0; i < numMobsBase + numMobsOffset; i++)
			GenerateEnemy();
	}

	void GenerateEnemy()
	{
		Room spawnRoom = levelGen.GetRandomRoom ();

		if (spawnRoom == null)
			return;

		Vector3 SpawnLocation = spawnRoom.getCenterSpawnPoint();
		
		EnemyAI temp = ((GameObject)GameObject.Instantiate (Prefab, SpawnLocation, Quaternion.identity)).GetComponent<EnemyAI>();
		temp.LateAwake ();
	}
}
