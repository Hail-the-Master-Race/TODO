using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum statIndex
{
    STR = 0,
    FRT,
    DEX,    
    MAX
}

public class Character
{
    private string Name;
    private Dictionary<statIndex, int> StartingStats;

    private const int totalStatPoints = 15;
    
    public Character ()
    {
        Name = "";
       
        StartingStats = new Dictionary<statIndex, int> ();

        StartingStats.Add (statIndex.STR, 0);
        StartingStats.Add (statIndex.FRT, 0);
        StartingStats.Add (statIndex.DEX, 0);

        StartingStats [statIndex.STR] = 0;
        StartingStats [statIndex.FRT] = 0;
        StartingStats [statIndex.DEX] = 0;
        
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
    
    public int getStartingStat (statIndex index)
    {
        return StartingStats [index];
    }

    public void setName (string name)
    {
        Name = name;
    }
}

public class CharacterCreateScript : MonoBehaviour
{
    private UIController UI;

    private Character PC = new Character ();

    public void Start ()
    {
        InitClasses ();
        RerollStats ();
    }

    private void InitClasses ()
    {
        return;
    }   

    public void ClassSelectionChange ()
    {
        UI = GetComponent<UIController> ();
        UI.UpdateClassSelection ();

        RerollStats ();
    }

    public void PCNameChange ()
    {
        UIInput NameInput = GameObject.Find ("Name: Input")
            .GetComponent<UIInput> ();

        PC.setName (NameInput.value);
    }

    public void RerollStats ()
    {
        PC.RerollStats ();
        UI = GetComponent<UIController> ();

        UI.UpdateStatTable (PC.getStartingStat (statIndex.STR),
                            PC.getStartingStat (statIndex.DEX),
                            PC.getStartingStat (statIndex.FRT));

    }

    public void StartGame ()
    {
        return;
    }
}