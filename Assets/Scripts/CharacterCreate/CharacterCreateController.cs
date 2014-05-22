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

public class CharacterCreateController : MonoBehaviour
{
    private UIController UI;
    private Character PC;
    private UIInput NameInput;
    private UIPopupList ClassSelectList;

    private const int RerollMax = 15;
    [Range(0,100)]
    public int
        RerollRemaining = RerollMax;

    void Awake ()
    {
        Object.DontDestroyOnLoad (GameObject.Find ("PC Packet"));
        PC = GameObject.Find ("PC Packet").GetComponent<Character> ();
        UI = GetComponent<UIController> ();
        ClassSelectList = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();
        NameInput = GameObject.Find ("Name: Input")
            .GetComponent<UIInput> ();
    }

    public void ClassSelectionChange ()
    {
        string ClassSelectionKey = ClassSelectList.value.Trim ();

        PC.Class = CharacterClasses.getClass (ClassSelectionKey);

        UI.UpdateClassSelection ();

        RerollReset ();
        RerollStats ();
    }

    private void RerollReset ()
    {
        RerollRemaining = RerollMax;
    }

    public void PCNameChange ()
    {
        PC.Name = NameInput.value;
    }

    public void RerollStats ()
    {
        if (RerollRemaining == 0)
            return;

        RerollRemaining--;

        PC.RerollStats ();

        UI.UpdateStatTable ();
        UI.UpdateRerollCounter ();
    }

    public void StartGame ()
    {
        Application.LoadLevel ("StartScene");
        return;
    }
}