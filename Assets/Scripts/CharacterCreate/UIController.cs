using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    private UILabel ClassDescriptorLabel;
    private UIPopupList ClassSelector;

    private UILabel LabelSTR;
    private UILabel LabelFRT;
    private UILabel LabelDEX;     

    private Character PC;

    public void Awake ()
    {
        PC = GameObject.Find ("PC Packet").GetComponent<Character> ();        

        ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();
        
        ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();

        LabelSTR = GameObject.Find ("STR: Value")
            .GetComponent<UILabel> ();
        LabelFRT = GameObject.Find ("FRT: Value")
            .GetComponent<UILabel> ();
        LabelDEX = GameObject.Find ("DEX: Value")
            .GetComponent<UILabel> ();
    }

    public void UpdateClassSelection ()
    {
        ClassDescriptorLabel.text = PC.Class.Description;
    }

    public void UpdateStatTable ()
    {
        LabelSTR.text = PC.StartingStats [statIndex.STR].ToString ();
        LabelDEX.text = PC.StartingStats [statIndex.DEX].ToString ();
        LabelFRT.text = PC.StartingStats [statIndex.FRT].ToString ();
    }

    public void UpdateRerollCounter ()
    {
        return;
    }
}
