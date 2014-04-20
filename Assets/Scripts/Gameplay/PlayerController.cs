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
	
	
	private Animator playerAnimator;    	// Player's animator
	private HashIDs hash;               	// HashIDs for GameController
	private CharacterController controller; // Player's character controller
	private Camera mainCamera;

	private float verticalVel = 0f;			// Player's vertical velocity
	
	
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
		// Jumping will be implemented here
		if (controller.isGrounded) {
			Debug.Log ("On the ground!");
		} else {
			verticalVel += Physics.gravity.y * Time.deltaTime;
			return;
		}

		// Check for forward/backward motion
		if(vertical != 0f)
		{
			// We are moving forward
			if(vertical > 0) {
				playerAnimator.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
			}
			else { // We are moving backward
				playerAnimator.SetFloat(hash.speedFloat, -5.5f, speedDampTime, Time.deltaTime);
			}
		}
		else
			// Otherwise set the speed parameter to 0
			playerAnimator.SetFloat(hash.speedFloat, 0);

		// Roate based on mouse, independent of movement
		Rotate (rotation);
	}
	
	
	void Rotate (float rotation)
	{
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