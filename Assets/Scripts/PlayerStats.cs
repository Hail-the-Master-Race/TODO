using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl = 1;
    public int Lvl { get { return lvl; } }
    public string name = "PC Placeholder Name";

    public int currentHP = 100;
    private int maxHP = 100;
    public int MaxHP { get { return maxHP; } }

    public int currentMP = 100;
    private int maxMP = 100;
    public int MaxMP { get { return maxMP; } }

    public int currentHunger = 100;
    private int maxHunger = 100;
    public int MaxHunger { get { return maxHunger; } }

    public int currentEXP = 10;
    private int maxEXP = 100;
    public int MaxEXP { get { return maxEXP; } }
}
