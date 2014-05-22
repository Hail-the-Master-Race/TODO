using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float turnSmoothing = 15f;   // A smoothing value for turning the player
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	public bool attacking;
	
	private Animator playerAnimator;    	// Player's animator
	private HashIDs hash;               	// HashIDs for GameController
	private CharacterController controller; // Player's character controller
	private Camera mainCamera;

	private float verticalVel = 0f;			// Player's vertical velocity
	private float speed;
	
	
	void Start ()
	{
		playerAnimator = GetComponent<Animator>();
		controller = (CharacterController)GetComponent (typeof(CharacterController));
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		mainCamera = Camera.main;
	}
	
	void Update ()
	{
		// Will probably need later for sounds and stuff
	}
	
	void FixedUpdate ()
	{
		// Cache the inputs
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		float rot = Input.GetAxis ("Mouse X");

		UpdateMovement (h, v, rot);
	}
	
	void UpdateMovement (float horizontal, float vertical, float rotation)
	{
		// This needs to be turned off when NOT in networking mode
		if (!networkView.isMine)
			return;
		// keep the character grounded!
		verticalVel += Physics.gravity.y * Time.deltaTime;
		controller.Move (new Vector3 (0, verticalVel, 0) * Time.deltaTime);

		if (controller.isGrounded) {
			Debug.Log ("Grounded!");

			if (Input.GetButtonDown ("Fire1")) {
				playerAnimator.SetBool (hash.attackBool, true);
				attacking = true;
				return;
			}
			else {
				if(!playerAnimator.GetBool(hash.attackBool))
					attacking = false;
			}

			verticalVel = 0;
			playerAnimator.SetBool (hash.jumpingBool, false);


			if (vertical != 0f) {
				if (vertical > 0) 
					// We are moving forward
					speed = 5.5f;
				else 
					// We are moving backward
					speed = -5.5f; 

				playerAnimator.SetFloat (hash.speedFloat, speed, speedDampTime, Time.deltaTime);
				controller.Move (transform.forward * speed * Time.deltaTime);

			} else // Otherwise set the speed parameter to 0
				playerAnimator.SetFloat (hash.speedFloat, 0);

			if (horizontal != 0f) {
				speed = (horizontal > 0) ? 5.5f : -5.5f;
				playerAnimator.SetFloat (hash.speedFloat, speed, speedDampTime, Time.deltaTime);
				controller.Move (transform.right * speed * Time.deltaTime);
			}

			// Roate based on mouse, independent of movement
			Rotate (rotation);

			// Check for jump
			if (Input.GetButtonDown ("Jump")) {
				playerAnimator.SetBool (hash.jumpingBool, true);
				verticalVel -= 20;
			}
		}

		// Check if we are falling
		else {
			Debug.Log ("Falling!");
		}
	}
	
	
	void Rotate (float rotation)
	{
		// This needs to be turned off when NOT in networking mode
		if (!networkView.isMine)
			return;
		Vector3 forward = mainCamera.transform.forward;
		Vector3 right = mainCamera.transform.right;

		// Direction depends on the camera
		Vector3 targetDirection = rotation * right + forward;
		targetDirection.y = 0f;
		
		// Create the rotation
		if (targetDirection != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection);
		
			// Create a rotation that is an increment closer to the target rotation from the player's rotation
			Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
			// Change the players rotation to this new rotation
			rigidbody.MoveRotation (newRotation);
		}
	}
}