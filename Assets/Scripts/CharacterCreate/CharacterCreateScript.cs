using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum statIndex
{
    STR = 0,
    FRT,
    DEX,    
    MAX
}

public class CharacterCreateScript : MonoBehaviour
{
    public int totalStatPoints = 15;

    private Dictionary<statIndex, int> statsCurr;

    void Start ()
    {
        RerollStats ();
    }
    private void InitStats ()
    {
        if (statsCurr == null)
            statsCurr = new Dictionary<statIndex, int> ();

        if (!statsCurr.ContainsKey (statIndex.STR))
            statsCurr.Add (statIndex.STR, 0);
        if (!statsCurr.ContainsKey (statIndex.FRT))
            statsCurr.Add (statIndex.FRT, 0);
        if (!statsCurr.ContainsKey (statIndex.DEX))
            statsCurr.Add (statIndex.DEX, 0);

        if (statsCurr [statIndex.STR] != 0) 
            statsCurr [statIndex.STR] = 0;
        if (statsCurr [statIndex.FRT] != 0)
            statsCurr [statIndex.FRT] = 0;
        if (statsCurr [statIndex.DEX] != 0)
            statsCurr [statIndex.DEX] = 0;
    }

    public void ClassSelectionChange ()
    {
        UILabel ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();
        
        UIPopupList ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        ClassDescriptorLabel.text = "Descriptor of " + ClassSelector.value;

        RerollStats ();
    }

    public void PCNameChange ()
    {
//        UIInput NameInput = GameObject.Find ("Name: Input")
//            .GetComponent<UIInput> ();
       
       
    }

    public void RerollStats ()
    {
        InitStats ();
        // TODO
        for (int i=0; i< totalStatPoints; i++) {
            statsCurr [(statIndex)Random.Range (0, (int)statIndex.MAX)]++;
        }     

        UpdateStatTableValues ();
    }

    private void UpdateStatTableValues ()
    {
        UILabel LabelSTR = GameObject.Find ("STR: Value")
            .GetComponent<UILabel> ();
        UILabel LabelFRT = GameObject.Find ("FRT: Value")
            .GetComponent<UILabel> ();
        UILabel LabelDEX = GameObject.Find ("DEX: Value")
            .GetComponent<UILabel> ();

        LabelSTR.text = statsCurr [statIndex.STR].ToString ();
        LabelFRT.text = statsCurr [statIndex.FRT].ToString ();
        LabelDEX.text = statsCurr [statIndex.DEX].ToString ();
    }

    public void StartGame ()
    {
        return;
    }
}