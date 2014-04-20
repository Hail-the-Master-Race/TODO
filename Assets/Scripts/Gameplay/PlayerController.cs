using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	
	
	private Animator playerAnimator;    	// Reference to the animator component.
	private HashIDs hash;               	// Reference to the HashIDs.
	private CharacterController controller; // Reference to player's character controller.
	private Camera mainCamera;

	private float verticalVel = 0f;			// Player's vertical velocity.
	
	
	void Start ()
	{
		// Setting up the references.
		playerAnimator = GetComponent<Animator>();
		controller = (CharacterController)GetComponent (typeof(CharacterController));
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		mainCamera = Camera.main;
	}
	
	void Update ()
	{
		//will probably need later
	}
	
	void FixedUpdate ()
	{
		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		
		UpdateMovement(h, v);
	}
	
	void UpdateMovement (float horizontal, float vertical)
	{
		if (controller.isGrounded) {
			Debug.Log ("On the ground!");
		} else {
			verticalVel += Physics.gravity.y * Time.deltaTime;
		}
		// If there is some axis input...
		if(horizontal != 0f || vertical != 0f)
		{
			// ... set the players rotation and set the speed parameter to 5.5f.
			if(vertical >= 0) {
				Rotate (horizontal, vertical);
				playerAnimator.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
			}
			else if (vertical < 0) {
				playerAnimator.SetFloat(hash.speedFloat, -5.5f, speedDampTime, Time.deltaTime);
			}
		}
		else
			// Otherwise set the speed parameter to 0.
			playerAnimator.SetFloat(hash.speedFloat, 0);
	}
	
	
	void Rotate (float horizontal, float vertical)
	{
		if (vertical == 0)
			vertical += 1;

		Vector3 forward = mainCamera.transform.forward;
		Vector3 right = mainCamera.transform.right;

		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = horizontal * right + vertical * forward;
		targetDirection.y = 0f;
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		if (targetDirection != Vector3.zero) {
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection);
		
			// Create a rotation that is an increment closer to the target rotation from the player's rotation.
			Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
			// Change the players rotation to this new rotation.
			rigidbody.MoveRotation (newRotation);
		}
	}
}