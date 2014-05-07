using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    private UILabel ClassDescriptorLabel;
    private UIPopupList ClassSelector;

    private UILabel LabelSTR;
    private UILabel LabelFRT;
    private UILabel LabelDEX;

    void Start ()
    {
        ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();

        ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        LabelSTR = GameObject.Find ("STR: Value")
            .GetComponent<UILabel> ();
        LabelFRT = GameObject.Find ("FRT: Value")
            .GetComponent<UILabel> ();
        LabelDEX = GameObject.Find ("DEX: Value")
            .GetComponent<UILabel> ();
    }

    public void UpdateClassSelection ()
    {
        ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        ClassDescriptorLabel.text = "Descriptor of " + ClassSelector.value;
    }

    public void UpdateStatTable (int STR, int DEX, int FRT)
    {
        LabelSTR.text = STR.ToString ();
        LabelDEX.text = DEX.ToString ();
        LabelFRT.text = FRT.ToString ();
    }
}
