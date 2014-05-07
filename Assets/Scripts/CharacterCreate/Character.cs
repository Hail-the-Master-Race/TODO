using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{       
    public string Name;
    private CharacterClass Class;
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
            StartingStats [(statIndex)Random.Range (0, (int)statIndex.MAX)]++;
        }     
        return;
    }
    
    public Dictionary<statIndex,int> getStartingStats ()
    {
        return StartingStats;
    }
    
    public void setName (string name)
    {
        Name = name;
    }
}
