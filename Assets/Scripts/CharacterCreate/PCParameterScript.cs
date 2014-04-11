using UnityEngine;
using System.Collections;

public class PCParameterScript : MonoBehaviour
{

    UILabel ClassDescriptorLabel;
    
    void Start ()
    {
        ClassDescriptorLabel = GameObject.Find ("Label: Class Descriptor")
            .GetComponent<UILabel> ();
    }

    public void ClassSelectionChange ()
    {
        // TODO
        string ClassSelection = GameObject.Find ("List: Class Select")
            .GetComponent<UIPopupList> ().value;
        ClassDescriptorLabel.text = "Descriptor of " + ClassSelection;
    }
}
