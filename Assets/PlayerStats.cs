using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl = 1;
    public int HP = 100;
    public int MP = 100;

    public string name = "PC Placeholder Name";

    // Use this for initialization
    void Start ()
    {
    }

    public int getLevel ()
    {
        return lvl;
    }
	
    // Update is called once per frame
    void Update ()
    {
	
    }
}
