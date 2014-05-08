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

    public void UpdateClassSelection ()
    {
        ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();

        PC = GetComponent<Character> ();

        ClassDescriptorLabel.text = PC.getClass ().getDescription ();
    }

    public void UpdateStatTable (int STR, int DEX, int FRT)
    {
        LabelSTR = GameObject.Find ("STR: Value")
            .GetComponent<UILabel> ();
        LabelFRT = GameObject.Find ("FRT: Value")
            .GetComponent<UILabel> ();
        LabelDEX = GameObject.Find ("DEX: Value")
            .GetComponent<UILabel> ();

        LabelSTR.text = STR.ToString ();
        LabelDEX.text = DEX.ToString ();
        LabelFRT.text = FRT.ToString ();
    }
}
