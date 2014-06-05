using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class Level : MonoBehaviour {
	public Room[] roomsList;
	// array of rooms, to be ordered by starting interval
	public Room[][] roomIntervals = new Room[4][];
	// 0 = South Wall, 1 = West Wall,
	// 2 = North Wall, 3 = East Wall
	// used for corridor and intersection testing.

	public Corridor[] HorzIntervals = new Corridor[0];
	public Corridor[] VertIntervals = new Corridor[0];

	private Room[] temp;

	public int maxNumRooms = 1000;


	float delta = 6.0f; // corridor width


	public Rigidbody Wall_prefab;
	public Rigidbody Corridor_prefab;

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
	public void BuildCorridors (){
		Corridor cord;
		for (int i = 0; i < roomsList.Length; i++) {
			for (int j = 0; j<4; j++){
				cord = roomsList[i].corridors[j];
				if (cord != null && cord.rIndex1 == i){
					cord.BuildCorridor();
				}
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
	// creates intervals for testing room intersectons
	public void CreateRoomIntervals(){
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
		System.Array.Resize (ref VertIntervals, j * 2);
		System.Array.Resize (ref HorzIntervals, j * 2);
	}
	// creates intervals for testing corridor intersection
	public void CreateCordIntervals(){
		print ("Creating Corridor Intervals!");
		int horz = 0;
		int vert = 0;
		Corridor cord;
		for (int i = 0; i < roomsList.Length; i++) {
			for (int j = 0; j <4; j++){
				cord = roomsList[i].corridors[j];
				if (cord != null && cord.rIndex1 == i){
					if ((j % 2) == 0){ // vertical corridors
						HorzIntervals[horz] = cord; 
						horz++;
					}
					else { // horizontal corridors
						VertIntervals[vert] = cord;
						vert++;
					}
				}
			}
		}
		print (roomsList.Length+"|"+horz+":"+vert);
		System.Array.Resize (ref HorzIntervals, horz);
		System.Array.Resize (ref VertIntervals, vert);
		HorzIntervals = HorzIntervals.OrderBy (r => r.start.x).ToArray ();
		VertIntervals = VertIntervals.OrderBy (r => r.start.z).ToArray ();
	}
	// Makes doors in passage way X junctions
	public void MakeDoors(){
		Corridor cord;
		Corridor inter;
		Vector3 start, end;
		Vector3 startTemp, endTemp;
		for (int i = 0; i < roomsList.Length; i++) {
			for (int j = 0; j<4; j++){
				cord = roomsList[i].corridors[j];
				if (cord != null && cord.rIndex1 == i){
					int k = 0;
					bool scan = true;
					if ((j % 2) == 0){
						start = cord.start;
						end = cord.end;
						if (start.z > end.z){
							start = cord.end;
							end = cord.start;
						}
						while(scan && k < VertIntervals.Length){
							startTemp = VertIntervals[k].start;
							endTemp = VertIntervals[k].end;
							if (startTemp.x > endTemp.x){
								startTemp = VertIntervals[k].end;
								endTemp = VertIntervals[k].start;
							}
								
							if (endTemp.z > end.z){
								scan = false;
							}
							if (startTemp.z > start.z && 
							    startTemp.x < start.x &&
							    endTemp.x > start.x){
								cord.doors.Add(new Vector3(start.x,0,startTemp.z));
							}
							k++;
						}
					}

					else{
						start = cord.start;
						end = cord.end;
						if (cord.start.x > cord.end.x){
							start = cord.end;
							end = cord.start;
						}
						while(scan &&  k < HorzIntervals.Length){
							startTemp = HorzIntervals[k].start;
							endTemp = HorzIntervals[k].end;
							if (startTemp.z > endTemp.z){
								startTemp = HorzIntervals[k].end;
								endTemp = HorzIntervals[k].start;
							}
							if (endTemp.x > end.x){
								scan = false;
							}
							if (startTemp.x > start.x && 
							    startTemp.z < start.z &&
							    endTemp.z > start.z){
								cord.doors.Add(new Vector3(startTemp.x,0,start.z));
							}
							k++;

							}
						}
					}
				}
			}
	}


	// attempts to draw a straight corridor between roooms/points. Can also be used to generate L junctions
	public bool TestStraight(ref float sMaxC, ref float sMinC, float eMaxC, float eMinC){
		if ((Mathf.Floor(sMaxC) - Mathf.Ceil(eMinC)) > delta && (Mathf.Floor(eMaxC) - Mathf.Ceil(sMinC)) > delta){
			sMaxC = Mathf.Floor(Mathf.Min(sMaxC,eMaxC));
			sMinC = Mathf.Ceil(Mathf.Max(sMinC,eMinC));
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

	// used for different corridor generation algorithm, not fully implimented
	public Corridor DiagCord (float max, float min,int maxI, int minI, Room start, Room end,int i, int wall){
		var interval = roomIntervals[wall];
		Room temp;
		float farbound = end.bounds [wall];
		float sMax = max;
		float sMin = min;
		bool search = true;
		while (search && i < interval.Length){
			temp = interval[i];
			if (temp.bounds[(wall+2)%4] < farbound){ // check to see if we are too far
				var test = TestStraight (ref sMax, ref sMin,temp.bounds[maxI],temp.bounds[minI]);
				if (test) {
					return null;
				}
				else{
					i++;
				}
			}
			else{ //we went too far
				search = false;
			}
		}
		if (max-min < delta){
			return null;
		}
		else {
			float corner1 = (sMax + sMin)/2;
			// need to shift directions. 

		}
	return null;
	}

	// for a given room finds possible pathways to its neighbors
	public void SearchEdges(Room room, int wall){
		var interval = roomIntervals[wall];
		int i = 1+interval.ToList ().IndexOf (room);
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

		bool search = true;
		Corridor cord;
		while (search && i < interval.Length){
			temp = interval[i];
			if (max >= temp.bounds[minI] && temp.bounds[maxI] >= min){ // check if straight shot is possible
			var test = TestStraight (ref max, ref min,temp.bounds[maxI],temp.bounds[minI]); // test the edge for straight shot
				if (test){
					cord = new Corridor(Corridor_prefab, room.index,temp.index,max, min, 
					                          room.bounds[wall], temp.bounds[(wall+2)%4],wall);
					if (roomsList[room.index].corridors[wall] == null){
						roomsList[room.index].corridors[wall] = cord;
						roomsList[temp.index].corridors[(wall+2)%4] = cord;
						//cord.BuildCorridor(); // for testing / intersect

					}

				search = false;	// done searching
				//cord.BuildCorridor(); // MST location

				}
				else{
					if (max-min < delta){// no possible corridors found
						search = false; 
					}
				}
			}
			else{ // look for diagonal corridors
				cord = DiagCord(max, min,maxI, minI, room, temp,i, wall);
			}
			i+=1;
		}
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
			Room temp = new Room (Wall_prefab, c1,c2,c3,c4);
			// first round culling
			if (temp.area > minArea && temp.area < maxArea) {
				roomsList[i] = temp;
			}
		}
		CullRooms (); // Removes overlapping rooms
		IndexRooms (); // Indexes the rooms, fits array size to room numbers


		CreateRoomIntervals ();
		CreateEdges ();
		CreateCordIntervals ();
		MakeDoors ();
		BuildRooms (); // generates all the rooms
		BuildCorridors ();
		print ("vec:" + Vector3.Cross (new Vector3 (1, 0, 0), new Vector3 (0, 1, 0)));




		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
