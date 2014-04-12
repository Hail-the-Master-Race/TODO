using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	
	public float pos;
	public float turnSmoothing = 15f;
	public float speedDampTime = 0.1f;
	
	private HashIDs hash;
	private Animator playerAnimator;
	
	void Awake ()
	{
		playerAnimator = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}
	
	void UpdateMovement (float horizontalMovement, float verticalMovement)
	{
		if (horizontalMovement != 0 || verticalMovement != 0) {
			Rotating (horizontalMovement, verticalMovement);
			playerAnimator.SetFloat (hash.speedFloat, 1.0f, speedDampTime, Time.deltaTime);
		}
		else
			playerAnimator.SetFloat(hash.speedFloat, 0);
	}
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		
		UpdateMovement (h, v);
	}
	
	void Update()
	{
		playerAnimator.SetBool(hash.jumpingBool, false);
		playerAnimator.SetBool(hash.attackBool, false);
	}
	
	void Rotating(float horizontal, float vertical) {
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3 (horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation (newRotation);
	}
}
