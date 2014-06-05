using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	// Here we store the hash tags for various strings used in our animators.
	public int blendState;
	public int attackState;
	public int jumpState;
	public int speedFloat;
	public int jumpingBool;
	public int attackBool;
	public int idleState;
	public int lumberState;
	public int walkState;

	void Awake ()
	{
		blendState = Animator.StringToHash("Base Layer.Blend Tree");
		attackState = Animator.StringToHash("Base Layer.Attack");
		jumpState = Animator.StringToHash("Shouting.Jump");
		speedFloat = Animator.StringToHash("Speed");
		jumpingBool = Animator.StringToHash("Jump");
		attackBool = Animator.StringToHash("Attack");
		walkState = Animator.StringToHash("Walk");
		lumberState = Animator.StringToHash("Lumbering");
		idleState = Animator.StringToHash("Idle");
	}
}