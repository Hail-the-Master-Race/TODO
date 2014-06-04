using UnityEngine;
using System.Collections;


public class Level : MonoBehaviour {
	public Room[] roomsList;

	public Rigidbody prefab;

	public void BuildRooms(){
		for (int i = 0; i < roomsList.Length; i++){
				if (roomsList[i] != null){
				roomsList[i].BuildWalls();
			}
		}
	}
	public void CullRooms(){
		int counter = 0;
		Room rtest;
		for (int i = 0; i < roomsList.Length; i++){
			if (roomsList[i] != null){
				rtest = roomsList[i];
				for (int j = 0; j < i; j++){
					if (roomsList[j] != null){
						//print("Checking rooms:"+i+" and "+j);
						if (rtest.IntersectsWithBuffer(roomsList[j],2f)){
							//print ("Culling "+j);
							counter++;
							roomsList[j] = null;
						}
					}
				}
			}
		}
		print ("Culled " + counter + " rooms!"); 
	}
	public void IndexRooms(){
		Room[] temp = new Room[1000];
		int j = 0;
		for (int i = 0; i < roomsList.Length; i++)
			if (roomsList[i] != null){
				temp[j] = roomsList[i];
				temp[j].index = j;
				j++;
		}
		System.Array.Resize (ref temp, j);
		roomsList = temp;
	}

//  todo
//	public void BuildPaths(){
//
//	}


	// Use this for initialization
	void Start () {
		//room building info
		//hardcoded for now
		roomsList = new Room[1000];
		int maxRooms = 100;
		int levelScale = 50;
		int roomMin = 3;
		int roomMax = 5;
		float maxArea = 500.0f;
		float minArea = 10.0f;
		for (int i = 0; i<maxRooms; i++){

			float x = Mathf.Round (Random.Range (roomMin, roomMax));
			float y = Mathf.Round (Random.Range (roomMin, roomMax));
			float cx = Mathf.Round (Random.Range (-levelScale, levelScale));
			float cy = Mathf.Round (Random.Range (-levelScale, levelScale));

			Vector3 c1 = new Vector3 (cx-x, 0f, cy+y);
			Vector3 c2 = new Vector3 (cx+x, 0f, cy+y);
			Vector3 c3 = new Vector3 (cx+x, 0f, cy-y);
			Vector3 c4 = new Vector3 (cx-x, 0f, cy-y);
			Room temp = new Room (prefab, c1,c2,c3,c4);
			// first round culling
			if (temp.area > minArea && temp.area < maxArea) {
				roomsList[i] = temp;
			}
		}
		CullRooms (); // Removes overlapping rooms
		IndexRooms (); // Indexes the rooms, fits array size to room numbers
		BuildRooms (); // generates all the rooms

		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
