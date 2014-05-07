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

public class CharacterClass
{
    private string Name;
    private string Description;
    
    private int AffinSTR;
    private int AffinDEX;
    private int AffinFRT;
    
    public CharacterClass (string name, string description,
                           int aS, int aD, int aF)
    {
        Name = name;
        Description = description;
        AffinSTR = aS;
        AffinDEX = aD;
        AffinFRT = aF;
    }

    public string getName ()
    {
        return Name;
    }
}


public class CharacterCreateScript : MonoBehaviour
{
    private UIController UI;
    private Character PC;
    private Dictionary<string, CharacterClass> Classes;

    public void Start ()
    {
        PC = GetComponent<Character> ();
        InitClasses ();
        RerollStats ();
    }

    private void InitClasses ()
    {
        CharacterClass ClassWarrior = new CharacterClass ("Warrior",
                                                          "Warrior Description",
                                                          4, 2, 3);
        CharacterClass ClassRogue = new CharacterClass ("Rogue",
                                                        "Rogue Description",
                                                        3, 4, 2);
        CharacterClass ClassDefender = new CharacterClass ("Defender",
                                                           "Defender Description",
                                                           3, 2, 4);
        CharacterClass ClassPeasant = new CharacterClass ("Peasant",
                                                          "Peasant Description",
                                                          3, 3, 3);


        if (Classes == null)
            Classes = new Dictionary<string, CharacterClass> ();
        if (!Classes.ContainsKey (ClassWarrior.getName ()))
            Classes.Add (ClassWarrior.getName (), ClassWarrior);
        if (!Classes.ContainsKey (ClassRogue.getName ()))
            Classes.Add (ClassRogue.getName (), ClassRogue);
        if (!Classes.ContainsKey (ClassDefender.getName ()))
            Classes.Add (ClassDefender.getName (), ClassDefender);
        if (!Classes.ContainsKey (ClassPeasant.getName ()))
            Classes.Add (ClassPeasant.getName (), ClassPeasant);

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
        PC = GetComponent<Character> ();
        PC.RerollStats ();

        UI = GetComponent<UIController> ();
        UI.UpdateStatTable (PC.getStartingStats () [statIndex.STR],
                            PC.getStartingStats () [statIndex.DEX],
                            PC.getStartingStats () [statIndex.FRT]);

    }

    public void StartGame ()
    {
        return;
    }
}