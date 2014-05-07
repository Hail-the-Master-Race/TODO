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

public class CharacterCreateScript : MonoBehaviour
{
    private UIController UI;
    private Character PC;

    public void Start ()
    {
        PC = GetComponent<Character> ();
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
        PC = GetComponent<Character> ();
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