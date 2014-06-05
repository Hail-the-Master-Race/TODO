using UnityEngine;
using System.Collections;

public class Corridor {


	public int index;
	
	public int rIndex1;	
	public int rIndex2;
	
	public Vector3 start; //center of range
	public Vector3 end; //range of placement around end
	public Vector3 mid;

	public float sRange; //range of placement around start
	public float eRange; //range of placement around end
						 // if mid on SE then sRange = eRange


	// Use this for initialization
	public Corridor (int r1, int r2, float sMax, float sMin, float sWall, float eWall, int wall){
		Vector3 start;
		float center = sMax - sMin;
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
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
