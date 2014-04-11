using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public string name = "PLACEHOLDER";
    private int lvl;

    public float pos;
    Animator playerAnimator;
    float speed = 0f;
    float direction = 0f;
	
    void Start ()
    {
        lvl = 1;
        speed = 0f;
        playerAnimator = GetComponent<Animator> ();
    }

    public int getLevel ()
    {
        return lvl;
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
	
    void UpdateMovement ()
    {
        direction = Input.GetAxis ("Horizontal");

        if (direction != 0)
            AddSpeed (direction * 0.01f);
        else
            SetSpeed (0f);
		
        pos += speed * Time.deltaTime;
    }
	
    void Update ()
    {
        UpdateMovement ();
    }
}
