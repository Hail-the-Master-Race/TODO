using UnityEngine;
using System.Collections;

public class UILabelScript : MonoBehaviour
{
    GameObject PC;
    PlayerStats PCStats;
    UILabel labelPCName;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.FindGameObjectWithTag ("Player");
        PCStats = PC.GetComponent<PlayerStats> ();
        labelPCName = GameObject.FindGameObjectWithTag ("UI: PC Info")
            .GetComponent<UILabel> ();
    }
	
    // Update is called once per frame
    void Update ()
    {
        labelPCName.text = PCStats.name;
        labelPCName.text += (" Lvl." + PCStats.getLevel ());
    }
}
