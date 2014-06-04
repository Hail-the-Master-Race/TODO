using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public EnemyStats stats;

	private Animator enemyAnimator;
	private HashIDs hash;
	public bool attacking = false;

	public void Start() {
		//enemyAnimator = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}

	public void Update() {
		//enemyAnimator.SetBool (hash.attackBool, true);
		attacking = true;
	}
}
