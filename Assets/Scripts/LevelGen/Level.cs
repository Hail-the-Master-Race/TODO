using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Level : MonoBehaviour {
	public Room[] roomsList;
	// array of rooms, to be ordered by starting interval
	public Room[][] roomIntervals = new Room[4][];
	// 0 = South Wall, 1 = West Wall,
	private Room[] temp;

	public int maxNumRooms = 1000;
	// 2 = North Wall, 3 = East Wall
	// used for corridor and intersection testing.

	float delta = 4.0f; // corridor width


	public Rigidbody prefab;

	void Awake()
	{
		roomsList = new Room[maxNumRooms];
		temp = new Room[maxNumRooms];

		GenerateRooms ();
	}

	public Room GetRandomRoom()
	{
		return roomsList [Random.Range (0, roomsList.Length)];
	}


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
		int j = 0;
		for (int i = 0; i < roomsList.Length; i++)
			if (roomsList[i] != null){
				temp[j] = roomsList[i];
				temp[j].index = j;
				//rooms.Add(roomsList[i]);
				j++;
		}
		System.Array.Resize (ref temp, j);
		roomsList = temp;
	}

	public void CreateIntervals(){
		print ("Creating Intervals!");
		int j= roomsList.Length;
		for (int i = 0; i < 4; i++){
			roomIntervals[i] = new Room[0];
			System.Array.Resize(ref roomIntervals[i],j);
		}
		roomIntervals[0] = roomsList.OrderBy (r => r.zMin).ToArray();
		roomIntervals[1] = roomsList.OrderBy (r => r.xMin).ToArray();
		roomIntervals[2] = roomsList.OrderByDescending (r => r.zMax).ToArray();
		roomIntervals[3] = roomsList.OrderByDescending (r => r.xMax).ToArray();
		int derp = roomIntervals[3][5].index;
		var test = roomIntervals [3].Single (item => item.index == derp);
		//print ("Test: " + test.index +":"+derp);
	}
	public bool TestEdge(ref float sMaxC, ref float sMinC, float eMaxC, float eMinC){
		if ((sMaxC - eMinC) > delta && (eMaxC - sMinC) > delta){
			sMaxC = Mathf.Min(sMaxC,eMaxC);
			sMinC = Mathf.Max(sMinC,eMinC);
			return true;
		}
		else{
			if (eMaxC <= sMaxC){
				sMinC = Mathf.Max(sMinC,eMaxC);
			}
			if (eMinC >= sMinC){
				sMaxC = Mathf.Min(sMaxC,eMinC);
			}
			return false;
		}
	}
	public void SearchEdges(Room room, int wall){
		var interval = roomIntervals[wall];
		int i = 1+interval.ToList ().IndexOf (room);
		//print ("Starting search for room:" + room.index+" at "+(i-1));
		Room temp;
		int maxI, minI;
		// set up the walls
		if (wall % 2 == 0){ //even
			maxI = 1;
			minI = 3; 
		}
		else { // odd
			maxI = 0; 
			minI = 2;
		}
		float max = room.bounds [maxI];
		float min = room.bounds [minI];
		print (max + "/" + min);
		print ("x:" + room.xMax + "/" + room.xMin);
		print ("z:" + room.zMax + "/" + room.zMin);

		bool search = true;
		print ("Room center 1:" + room.center);
		while (search && i < interval.Length){
			//print("Searching interval:"+i);
			temp = interval[i];
			// first test for corners?
			var test = TestEdge (ref max, ref min,temp.bounds[maxI],temp.bounds[minI]);
			//print ("Room center "+i+":" + temp.center);

			if (test){
				//if (room.Corridors[wall] != null){ write update later?
				roomsList[room.index].corridors[wall] = new Corridor(room.index,temp.index,
				                              max, min, room.bounds[wall],
				                              temp.bounds[(wall+2)%4],wall);
				print ("found it");
				//roomsList[room.index].corridors[wall].BuildCorridor();
				var thi = roomsList[room.index].corridors[wall];
				thi.BuildCorridor();
//				print("Room: "+room.index+" to "+temp.index);
//				print ("centers; " + room.center + "/" +temp.center);
//				
				print("Cord:" + thi.start + "/"+thi.end+"-"+thi.inc);
//				print ("min/max:"+min+"/"+max);
				search = false;
			}
			else{
				if (max-min < delta){// no possible corridors found
					search = false; 
				} // else keep searching
			}
			i+=1;
		}
		//print ("ending search for "+ room.index+"with b:" + search + "and i:" + i);
	}


	public void CreateEdges(){
		for (int j = 0; j < 4; j++){
			for (int i = 0; i < roomsList.Length; i++){
			SearchEdges (roomsList [i], j);
			}
		}
	}

	// Use this for initialization
	void GenerateRooms () {
		//room building info
		//hardcoded for now
		roomsList = new Room[1000];
		int maxRooms = 100;
		int levelScale = 100;
		int roomMin = 3;
		int roomMax = 10;
		float maxArea = 500.0f;
		float minArea = 50.0f;
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
		//print ("center:" + roomsList[0].center);
		IndexRooms (); // Indexes the rooms, fits array size to room numbers
		//print ("center:" + roomsList[0].center);

		BuildRooms (); // generates all the rooms
		CreateIntervals ();
		CreateEdges ();

		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
