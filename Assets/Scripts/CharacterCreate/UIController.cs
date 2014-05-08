using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    private CharacterCreateController CharacterCreateController;

    private Character PC;

    private UILabel ClassDescriptorLabel;

    private UILabel RerollCounter;

    private UILabel LabelSTR;
    private UILabel LabelFRT;
    private UILabel LabelDEX;     


    public void Awake ()
    {
        CharacterCreateController = GetComponent<CharacterCreateController> ();

        PC = GameObject.Find ("PC Packet").GetComponent<Character> ();        
        
        ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();

        RerollCounter = GameObject.Find ("Remaining Rerolls: Value")
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
        RerollCounter.text 
            = CharacterCreateController.RerollRemaining.ToString ();
        return;
    }
}
