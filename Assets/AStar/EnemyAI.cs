using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
	Transform target;
	Transform myTransform; 
	public float speed = 3f;

	enum State
	{ IDLE,
	 MOVING,
	}

	float m_speed;
	float m_speed_multi = 5;
	bool onNode = true;
	Vector3 m_target = new Vector3(0, 0, 0);
	Vector3 currNode;
	int nodeIndex;
	List<Vector3> path = new List<Vector3>();
	Node control;
	State state = State.IDLE;
	float OldTime = 0;
	float checkTime = 0;
	float elapsedTime = 0;

	Animation enemyAnimator;

	void Awake()
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
		//transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation

		float distance = Vector3.Distance (transform.position, target.position);

		if (distance >= 5f) {
			enemyAnimator.Play("Idle");
			return;
		}

		if (distance < 5f && distance >= 2){//move if distance from target is greater than 1
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
			enemyAnimator.Play ("Walk");
		}

		if (distance < 2) {
			speed = 0f;
			enemyAnimator.Play("Lumbering");
			return;
		}

		m_speed = Time.deltaTime * m_speed_multi;
		elapsedTime += Time.deltaTime;
		
		if (elapsedTime > OldTime)
		{
			switch (state)
			{
			case State.IDLE:
				break;
				
			case State.MOVING:
				OldTime = elapsedTime + 0.01f;
				
				if (elapsedTime > checkTime)
				{
					checkTime = elapsedTime + 1;
					SetTarget();
				}
				
				if (path != null)
				{
					if (onNode)
					{
						onNode = false;
						if (nodeIndex < path.Count)
							currNode = path[nodeIndex];
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
		
		/***Move toward waypoint***/
		Vector3 motion = currNode - newPos;
		motion.Normalize();
		newPos += motion * m_speed;
		
		transform.position = newPos;
	}
	
	private void SetTarget()
	{
		path = control.Path(transform.position, m_target);
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

	
	
	