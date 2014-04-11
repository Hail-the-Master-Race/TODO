using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl;
    public int HP;
    public int MP;

    public string name;

    // Use this for initialization
    void Start ()
    {
        HP = 100;
        MP = 100;

        name = "PC Placeholder Name";
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
