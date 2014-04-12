using UnityEngine;
using System.Collections;

public class CharacterCreateScript : MonoBehaviour
{
    public void ClassSelectionChange ()
    {
        UILabel ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();
        
        UIPopupList ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        ClassDescriptorLabel.text = "Descriptor of " + ClassSelector.value;
    }

    public void PCNameChange ()
    {
//        UIInput NameInput = GameObject.Find ("Name: Input")
//            .GetComponent<UIInput> ();
       
       
    }

    public void RerollStats ()
    {
        return;
    }

    public void StartGame ()
    {
        return;
    }
}
