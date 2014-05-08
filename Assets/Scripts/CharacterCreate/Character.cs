using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{       
    private string _name;
    public string Name { 
        set { _name = value; } 
        get { return _name; }
    }

    private CharacterClass _class;
    public CharacterClass Class { 
        set { _class = value; } 
        get { return _class; }
    }

    private Dictionary<statIndex, int> StartingStats;

    [Range(0,100)]
    public int
        totalStatPoints = 15;

    void Start ()
    {
        Name = "";
        InitStats ();
    }

    private void InitStats ()
    {
        if (StartingStats == null)
            StartingStats = new Dictionary<statIndex, int> ();
        
        if (!StartingStats.ContainsKey (statIndex.STR))
            StartingStats.Add (statIndex.STR, 0);
        if (!StartingStats.ContainsKey (statIndex.FRT))
            StartingStats.Add (statIndex.FRT, 0);
        if (!StartingStats.ContainsKey (statIndex.DEX))
            StartingStats.Add (statIndex.DEX, 0);
        
        if (StartingStats [statIndex.STR] != 0) 
            StartingStats [statIndex.STR] = 0;
        if (StartingStats [statIndex.FRT] != 0)
            StartingStats [statIndex.FRT] = 0;
        if (StartingStats [statIndex.DEX] != 0)
            StartingStats [statIndex.DEX] = 0;
    }

    public void RerollStats ()
    {
        InitStats ();
        
        for (int i=0; i< totalStatPoints; i++) {
            int roll = Random.Range (0, 9);

            statIndex statAssignee;
            if (roll < Class.AffinSTR)
                statAssignee = statIndex.STR;
            else if ((roll -= Class.AffinSTR) < Class.AffinDEX)
                statAssignee = statIndex.DEX;
            else
                statAssignee = statIndex.FRT;

            StartingStats [statAssignee]++;
        }     
        return;
    }
    
    public Dictionary<statIndex,int> getStartingStats ()
    {
        return StartingStats;
    }
}
