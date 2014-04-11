using UnityEngine;
using System.Collections;

public class UILabelScript : MonoBehaviour
{
    GameObject PC;
    UILabel labelPCName;
    int t = 0;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.FindGameObjectWithTag ("Player");
        labelPCName = GetComponent<UILabel> ();
    }
	
    // Update is called once per frame
    void Update ()
    {
        labelPCName.text = PC.GetComponent<PlayerStats> ().name;
        labelPCName.text += (" Lvl." + PC.GetComponent<PlayerStats> ().getLevel ());
    }
}
