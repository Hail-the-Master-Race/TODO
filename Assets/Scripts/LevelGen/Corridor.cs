using UnityEngine;
using System.Collections;

public class Corridor {


	public int index;
	
	public int rIndex1;	
	public int rIndex2;
	
	public Vector3 start; //center of range
	public Vector3 end; //range of placement around end
	public Vector3 mid;
	public Vector3 inc; 
	public float sRange; //range of placement around start
	public float eRange; //range of placement around end
						 // if mid on SE then sRange = eRange
	public float height = 10; 
	public ArrayList doors = new ArrayList();
	public Rigidbody corridor_sec;


	// Use this for initialization
	public Corridor (Rigidbody prefab, int r1, int r2, float sMax, float sMin, float sWall, float eWall, int wall){
		float center = Mathf.Ceil((sMax + sMin)/2);
		if (wall % 2 == 0){
			start = new Vector3(center,0,sWall);
			mid = start + new Vector3(0,0,eWall-sWall/2);
			end = start + new Vector3(0,0,eWall-sWall);
		}
		else{
			start = new Vector3(sWall,0,center);
			mid = start + new Vector3(eWall-sWall/2,0,0);
			end = start + new Vector3(eWall-sWall,0,0);
		}

		rIndex1 = r1;
		rIndex2 = r2;
		corridor_sec = prefab;
	}
	public Corridor (int r1, int r2,Vector3 s, Vector3 m, Vector3 e,float sR, float eR){
		rIndex1 = r1;
		rIndex2 = r2;
		start = s;
		mid = m;
		e = end;
		sRange = sR;
		eRange = eR;

	}
	public void BuildCorridor(){
		Vector3 current = start;
		Vector3 goal = end;
		inc = (end-start).normalized;
		current += inc;
		while (current != goal){
			if (doors.Contains(current)){
				current += inc*1.0f;
			}
			else{
				// no prefabs
//				GameObject cube1 = GameObject.CreatePrimitive (PrimitiveType.Cube);
//				GameObject cube2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
//
//				cube1.AddComponent<Rigidbody> ();
//				cube1.transform.localScale = new Vector3(1f,height,1f);
//				cube1.transform.position = current + 2*Vector3.Cross(inc,Vector3.up);//	 + Vector3.up * .5f* height;
//				cube1.rigidbody.isKinematic = true;
//
//				cube2.AddComponent<Rigidbody> ();
//				cube2.transform.localScale = new Vector3(1f,height,1f);
//				cube2.transform.position = current + 2*Vector3.Cross(inc,Vector3.down);//	 + Vector3.up * .5f* height;
//				cube2.rigidbody.isKinematic = true;

				//prefab code
				GameObject.Instantiate(corridor_sec, current+2*Vector3.Cross(inc,Vector3.up),Quaternion.identity);
				GameObject.Instantiate(corridor_sec, current+2*Vector3.Cross(inc,Vector3.down),Quaternion.identity);
 				GameObject empty = new GameObject("corridornodes");
                empty.tag = "node";
                empty.transform.position = current + inc;
                current += inc*1.0f;
				current += inc*1.0f;
			}
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
