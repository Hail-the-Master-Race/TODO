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

    private Dictionary<statIndex, int> _startingStats;
    public Dictionary<statIndex, int> StartingStats {
        get { return _startingStats; }
    }

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
        if (_startingStats == null)
            _startingStats = new Dictionary<statIndex, int> ();
        
        if (!_startingStats.ContainsKey (statIndex.STR))
            _startingStats.Add (statIndex.STR, 0);
        if (!_startingStats.ContainsKey (statIndex.FRT))
            _startingStats.Add (statIndex.FRT, 0);
        if (!_startingStats.ContainsKey (statIndex.DEX))
            _startingStats.Add (statIndex.DEX, 0);
        
        if (_startingStats [statIndex.STR] != 0) 
            _startingStats [statIndex.STR] = 0;
        if (_startingStats [statIndex.FRT] != 0)
            _startingStats [statIndex.FRT] = 0;
        if (_startingStats [statIndex.DEX] != 0)
            _startingStats [statIndex.DEX] = 0;
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
}
