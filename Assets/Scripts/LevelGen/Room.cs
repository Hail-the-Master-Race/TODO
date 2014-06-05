using UnityEngine;
using System.Collections;

public class Room{//: MonoBehaviour {
	// room index number
	public int index;

	public Rigidbody wall_sec;
	//public Rect rect;
	// corners of the room
	public Vector3 centern;

	public Vector3[] corners = new Vector3[4];
	public Vector3[] incs = new Vector3[4];
	public float area;
	public Vector3 center;
	public float height = 10; 

	public Vector3 getCenterSpawnPoint()
	{
		float hOffset = (corners [1].x - corners [0].x) / 2.0f;
		float vOffset = (corners [3].z - corners [0].z) / 2.0f;

		return new Vector3 (Mathf.FloorToInt(corners[0].x + hOffset), 
		                    1, 
		                    Mathf.FloorToInt(corners[0].z + vOffset));
	}


	// used for intersection testing, saves recalculating
	public float[] bounds;
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;

	//Corridor Edges
	//ArrayList[] Corridors = new ArrayList[4];
	public Corridor[] corridors = new Corridor[4];

	public Room()
	{
		}
	public Room(Rigidbody prefab, Vector3 nw, Vector3 ne, Vector3 se, Vector3 sw)
	{
			//initialize the corners
			corners[0] = nw;
			corners[1] = ne;
			corners[2] = se;
			corners[3] = sw;
			
			//translate into rect coords
			xMin = sw.x;
			zMin = sw.z;	
			xMax = ne.x;
			zMax = ne.z;
			bounds = new float[4] {zMax, xMax, zMin, xMin};
			center = new Vector3 ((xMax + xMin)/2, 0.0f, (zMax + zMin)/2);
			//initialize the increiments
			incs[0] = Vector3.right;
			incs[1] = Vector3.back;
			incs[2] = Vector3.left;
			incs[3] = Vector3.forward;
			area = Vector3.Distance (nw, ne) * Vector3.Distance(nw, sw);

			wall_sec = prefab;


		}
		public bool IntersectsWithBuffer (Room r,float b){
			bool t1 = (xMax + b >= r.xMin);
			bool t2 = (xMin - b <= r.xMax);
			bool t3 = (zMax + b >= r.zMin);
			bool t4 = (zMin - b <= r.zMax);
		return (t1 && t2) && (t3 && t4);
		}


		public void BuildWall(Vector3 start, Vector3 end, Vector3 inc, int wall){
			Corridor cord = corridors [wall];
		Vector3 doorloc = Vector3.zero;
			if (cord != null){
				if(cord.rIndex1 == index) {
					doorloc = cord.start;
				} 
			else {
					doorloc = cord.end;
				}
			}
			Vector3 current = start;
			while (current != end) {
				if (cord != null && current == doorloc){
					current = current + inc*1.0f;
				}
				else{
//					GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//					cube.AddComponent<Rigidbody> ();
//					cube.transform.localScale = new Vector3(1f,height,1f);
//					cube.transform.position = current;//	 + Vector3.up * .5f* height;
//					cube.rigidbody.isKinematic = true;
				//prefab generation
					GameObject.Instantiate(wall_sec, current,Quaternion.identity);
					current = current + inc*1.0f;
				}
			}
			GameObject empty = new GameObject("roomnodes");
        	empty.tag = "node";
        	centern = new Vector3(center.x, center.y, center.z);
       		empty.transform.position = centern;
		}
		public void BuildWalls(){
			// cycle through each wall
			for (int i = 0; i<4; i++) {
				int j = i + 1;
				if (i == 3) {j = 0;}
				BuildWall (corners [i], corners [j], incs [i],i);
				}
			}

}
