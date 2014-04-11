using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl = 1;
    public string name = "PC Placeholder Name";

    public int currentHP = 100, maxHP = 100;
    public int currentMP = 100, maxMP = 100;

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
