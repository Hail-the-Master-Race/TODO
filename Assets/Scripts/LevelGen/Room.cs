using UnityEngine;
using System.Collections;


public class Room{//: MonoBehaviour {

//	public class Room
//	{	
		// corners of the room
	public Vector3[] corners = new Vector3[4];
	public Vector3[] incs = new Vector3[4];
	public float area;
	public float center;

	// used for intersection testing, saves recalculating
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
	//public Rect rect;

	public Room()
	{
//		int levelScale = 100;
//		int roomScale = 5;
//		//randomize
//		float cent = Mathf.Round(Random.Range(-levelScale, levelScale));
//		float xrad = Mathf.Round(Random.Range(-roomScale,roomScale));			
//		float yrad = Mathf.Round(Random.Range(-roomScale,roomScale));
//		//create the corners
//		corners [0] = new Vector3 (center - xrad, 0, center + yrad);
//		corners [1] = new Vector3 (center + xrad, 0, center + yrad);
//		corners [2] = new Vector3 (center + xrad, 0, center - yrad);
//		corners [3] = new Vector3 (center - xrad, 0, center - yrad);
//		area = 4 * xrad * yrad;
//		cent=cen
//	
		}
		public Room(Vector3 nw, Vector3 ne, Vector3 se, Vector3 sw)
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

			
			//initialize the increiments
			incs[0] = Vector3.right;
			incs[1] = Vector3.back;
			incs[2] = Vector3.left;
			incs[3] = Vector3.forward;
			area = Vector3.Distance (nw, ne) * Vector3.Distance(nw, sw);

		}
		public bool IntersectsWithBuffer (Room r,float b){
			bool t1 = (xMax + b >= r.xMin);
			bool t2 = (xMin - b <= r.xMax);
			bool t3 = (zMax + b >= r.zMin);
			bool t4 = (zMin - b <= r.zMax);
		return (t1 && t2) && (t3 && t4);
		}


		public void BuildWall(Vector3 start, Vector3 end, Vector3 inc){

			Vector3 current = start;
			while (current != end) {
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				GameObject myGameObject = new GameObject ();
				cube.AddComponent<Rigidbody> ();
				cube.transform.localScale = new Vector3(.5f,1f,.5f);
				cube.transform.position = current;//+ .5f * inc;
				myGameObject.transform.position = current;
				myGameObject.tag = "point";
				
				cube.rigidbody.isKinematic = true;
				current = current + inc*.5f;
				//current = end;

			}
		}
		public void BuildWalls(){
			// cycle through each wall
			for (int i = 0; i<4; i++) {
				int j = i + 1;
				if (i == 3) {j = 0;}
				BuildWall (corners [i], corners [j], incs [i]);
				}

			}



	// Use this for initialization
	void Start () {
//		float x = 100f;
//		Vector3 c1 = new Vector3 (-x, 0f, x);
//		Vector3 c2 = new Vector3 (x, 0f, x);
//		Vector3 c3 = new Vector3 (x, 0f, -x);
//		Vector3 c4 = new Vector3 (-x, 0f, -x);
//		Room test = new Room(c1,c2,c3,c4);
//		test.BuildWalls();

//      test.BuildWall (c1, c2, test.incs [0]);
//		test.BuildWall (c2, c3, test.incs [1]);
//		test.BuildWall (c1, c2, test.incs [0]);
//		test.BuildWall (c1, c2, test.incs [0]);
//
//

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
