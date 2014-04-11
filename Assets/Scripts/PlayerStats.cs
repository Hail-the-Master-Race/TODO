using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl;
    public int currentHP, maxHP;
    public int currentMP, maxMP;

    public string name = "PC Placeholder Name";

    // Use this for initialization
    void Start ()
    {
        currentHP = 100;
        currentMP = 100;

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
