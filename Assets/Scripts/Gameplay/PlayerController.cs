using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent(typeof (CharacterController))]
[AddComponentMenu("Third Person Player/Third Person Controller")]

public class PlayerController : MonoBehaviour {
	
	public float rotationDamping = 0.5f;
	public float pos;
	public float runSpeed = 0f;
	public int gravity = 20;
	public float jumpSpeed = 0f;
	float speed = 0f;

	private Animator playerAnimator;
	
	bool canJump;
	float moveSpeed;
	float verticalVel; // Used for continuing momentum while in air
	CharacterController controller;
	
	void Start()
	{
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		playerAnimator = GetComponent<Animator>();
	}
	void AddSpeed (float delta)
	{
		speed = Mathf.Clamp (speed + delta, -1f, 1f);
		playerAnimator.SetFloat ("Speed", speed);
	}
	
	void SetSpeed (float spd)
	{
		speed = spd;
		playerAnimator.SetFloat ("Speed", speed);
	}
	float UpdateMovement()
	{
		// Movement
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= runSpeed;
		
		//controller.Move((inputVec + Vector3.up * -gravity + new Vector3(0, verticalVel, 0)) * Time.deltaTime);
		
		// Rotation
		if (inputVec != Vector3.zero)
			transform.rotation = Quaternion.Slerp(transform.rotation,
			                                      Quaternion.LookRotation(inputVec),
			                                      Time.deltaTime * rotationDamping);

		if (Mathf.Abs(x) + Mathf.Abs(z) != 0)
			AddSpeed (((Mathf.Abs(x) + (Mathf.Abs(z)))) * 0.01f);
		else
			SetSpeed (0f);
		
		pos += speed * Time.deltaTime;

		return inputVec.magnitude;
	}
	void Update()
	{
		// Check for jump
		if (controller.isGrounded )
		{
			canJump = true;
			if ( canJump && Input.GetKeyDown("space") )
			{
				// Apply the current movement to launch velocity
				verticalVel = jumpSpeed;
				canJump = false;
			}
		}else
		{
			// Apply gravity to our velocity to diminish it over time
			verticalVel += Physics.gravity.y * Time.deltaTime;
		}
		
		// Actually move the character
		moveSpeed = UpdateMovement();

		//AddSpeed (moveSpeed * 0.01f);

		if ( controller.isGrounded )
			verticalVel = 0f;// Remove any persistent velocity after landing
	}
}
