using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {
	
	RaycastHit hit;
	bool leftClickFlag = true;
	
	public GameObject player;
	public GameObject enemy;
	public string floorTag;

	Player1 playerScript;
	EnemyAI enemyScript; 

	void Start()
	{
		if (player != null){
			playerScript = (Player1)player.GetComponent(typeof(Player1));
		}
		if (enemy != null){
			enemyScript = (EnemyAI)enemy.GetComponent(typeof(EnemyAI));
		}
//		else if(enemy == null) 
//		{Debug.Log ("enemy null", enemy);}
	}
	void Update () 
	{
		if (Input.GetKey(KeyCode.Mouse0) && leftClickFlag)
			leftClickFlag = false;
		
		if (!Input.GetKey(KeyCode.Mouse0) && !leftClickFlag)
		{
			leftClickFlag = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.transform.tag == floorTag)
				{
					float X = hit.point.x;
					float Z = hit.point.z;
					Vector3 target = new Vector3(X, player.transform.position.y, Z);
					Vector3 enemytarget = new Vector3(target.x, target.y, target.z);
					playerScript.MoveOrder(target);

					if(Vector3.Distance(enemytarget, target) < 5){
						enemyScript.MoveOrder(target);
					}

				}
			}
		}
	}
}
