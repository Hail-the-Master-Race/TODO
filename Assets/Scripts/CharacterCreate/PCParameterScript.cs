using UnityEngine;
using System.Collections;

public class PCParameterScript : MonoBehaviour
{

    UILabel ClassDescriptorLabel;
    
    void Start ()
    {
        ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();
    }

    public void ClassSelectionChange ()
    {
        // TODO
        string ClassSelection = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ().value;
        ClassDescriptorLabel.text = "Descriptor of " + ClassSelection;
    }
}
