using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
	//my target object
	public Transform target;
	Transform myTransform; 
	public float speed = 4f;
	
	enum State
	{ 
		IDLE,
		MOVING,
	}
	
	float m_speed;
	bool onNode = true;
	Vector3 m_target = new Vector3(0, 0, 0);
	Vector3 currNode;
	int nodeIndex;
	//path to follow
	public List<Vector3> route = new List<Vector3>();
	Node control;
	State state = State.IDLE;
	float OldTime = 0;
	float checkTime = 0;
	float elapsedTime = 0;
	
	//how to move our character
	Animation enemyAnimator;
	
	public void LateAwake()
	{
		myTransform = transform;
		GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		control = (Node)cam.GetComponent(typeof(Node));
		target = GameObject.FindWithTag("Player").transform;
		enemyAnimator = this.gameObject.GetComponent<Animation> ();
		
	}
	
	void Update () 
	{
		//rotate to look at the player
		transform.LookAt(new Vector3(target.position.x, 0, target.position.z));
		//transform.Rotate(new Vector3(0,-90,0),Space.Self); //correcting the original rotation
		
		float distance = Vector3.Distance (new Vector3(transform.position.x,0,transform.position.z), new Vector3(target.position.x,0,target.position.z));
		
		if (distance >= 13f) {
			MoveOrder(target.position);

			enemyAnimator.Play("Idle");
			return;
		}
		
		if (distance < 2f && distance >= 1f){//move if distance from target is greater than 1
			MoveOrder(target.position);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			enemyAnimator.Play ("Walk");
		}
		
		if (distance < 1f) {
			MoveOrder(target.position);
//			speed = 0f;
			enemyAnimator.Play("Lumbering");
			return;
		}
		
		m_speed = Time.deltaTime * 5.0f;
		elapsedTime += Time.deltaTime;
		
		if (elapsedTime > OldTime)
		{
			switch (state)
			{
			case State.IDLE:
				MoveOrder (target.position);
				break;
				
			case State.MOVING:
				OldTime = elapsedTime + 0.01f;
				
				if (elapsedTime > checkTime)
				{
					checkTime = elapsedTime + 1;
					SetTarget();
				}
				
				if (route != null)
				{
					if (onNode)
					{
						onNode = false;
						if (nodeIndex < route.Count)
							currNode = route[nodeIndex];
					} else {
						MoveToward();
						enemyAnimator.Play ("Walk");
					}
				}
				break;
			}
		}
	}
	
	void MoveToward()
	{
		Debug.Log ("moving");
		Vector3 newPos = transform.position;
		
		float Xdistance = newPos.x - currNode.x;
		if (Xdistance < 0) Xdistance -= Xdistance*2;
		float Ydistance = newPos.z - currNode.z;
		if (Ydistance < 0) Ydistance -= Ydistance*2;
		
		if ((Xdistance < 0.1 && Ydistance < 0.1) && m_target == currNode) //Reached target
		{
			ChangeState(State.IDLE);
		}
		else if (Xdistance < 0.1 && Ydistance < 0.1)
		{
			nodeIndex++;
			onNode = true;
		}
		
		Vector3 motion = currNode - newPos;
		motion.Normalize();
		newPos += motion * m_speed;
		
		newPos = new Vector3 (newPos.x, 0, newPos.z);
		transform.position = newPos;
	}
	
	private void SetTarget()
	{
		route = control.Path(transform.position, m_target);
		nodeIndex = 0;
		onNode = true;
	}
	
	public void MoveOrder(Vector3 pos)
	{
		m_target = pos;
		SetTarget();
		ChangeState(State.MOVING);
	}
	
	private void ChangeState(State newState)
	{
		state = newState;
	}
}



