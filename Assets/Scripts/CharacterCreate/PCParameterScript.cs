using UnityEngine;
using System.Collections;

public class PCParameterScript : MonoBehaviour
{
    public void ClassSelectionChange ()
    {
        UILabel ClassDescriptorLabel = GameObject.Find ("Class Descriptor")
            .GetComponent<UILabel> ();
        UIPopupList ClassSelector = GameObject.Find ("Class Select: List")
            .GetComponent<UIPopupList> ();

        string ClassSelection = ClassSelector.value;
        ClassDescriptorLabel.text = "Descriptor of " + ClassSelection;
    }
}
