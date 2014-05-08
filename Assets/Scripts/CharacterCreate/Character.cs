using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{       
    private string _name;
    public string Name { set { _name = value; } get { return _name; } }
    private CharacterClass _class;
    public CharacterClass Class { set { _class = value; } get { return _class; } }
    private Dictionary<statIndex, int> StartingStats;
    
    private const int totalStatPoints = 15;

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
            int roll = Random.Range (0, 9); // TODO: abstract out max affin ptVal

            statIndex statAssignee;
            if (roll < Class.getAffinSTR ())
                statAssignee = statIndex.STR;
            else if ((roll -= Class.getAffinSTR ()) < Class.getAffinDEX ())
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

    public CharacterClass getClass ()
    {
        return Class;
    }
}
