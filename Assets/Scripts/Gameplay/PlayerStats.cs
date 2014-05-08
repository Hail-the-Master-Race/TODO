using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    private int lvl = 1;
    public int Lvl { get { return lvl; } }
    public string name = "PC Placeholder Name";

    public string characterClass = "PC Placeholder Class";

    private int _maxHP = 100;
    public int MaxHP { get { return _maxHP; } }
    public int currentHP = 100;

    private int _maxMP = 100;
    public int MaxMP { get { return _maxMP; } }
    public int currentMP = 100;

    private int _maxHunger = 100;
    public int MaxHunger { get { return _maxHunger; } }
    public int currentHunger = 100;

    private int _maxEXP = 100;
    public int MaxEXP { get { return _maxEXP; } }
    public int currentEXP = 10;

    public int STR;
    public int DEX;
    public int FRT;

    public void Init (Character packet)
    {
        name = packet.Name == "" ? Strings.DefaultPCName : packet.Name;
        characterClass = packet.Class.Name;

        STR = packet.StartingStats [statIndex.STR];
        DEX = packet.StartingStats [statIndex.DEX];
        FRT = packet.StartingStats [statIndex.FRT];
    }
}
