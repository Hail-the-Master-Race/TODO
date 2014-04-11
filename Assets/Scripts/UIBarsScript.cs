using UnityEngine;
using System.Collections;

public class UIBarsScript : MonoBehaviour
{
    private GameObject PC;
    private PlayerStats PCStats;

    private GameObject BarHP, BarMP, BarHunger;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.FindGameObjectWithTag ("Player");
        PCStats = PC.GetComponent<PlayerStats> ();        

        BarHP = GameObject.FindGameObjectWithTag ("UI: HP Bar");
        BarMP = GameObject.FindGameObjectWithTag ("UI: MP Bar");
        BarHunger = GameObject.FindGameObjectWithTag ("UI: Hunger Bar");
    }
	
    // Update is called once per frame
    void Update ()
    {
        UpdateBars ();
    }

    void UpdateBars ()
    {
        UpdateHPBar ();
        UpdateMPBar ();
        UpdateHungerBar ();
    }

    void UpdateHPBar ()
    {
        BarHP.GetComponent<UISlider> ().value 
            = PCStats.currentHP / PCStats.maxHP;       
    }
    
    void UpdateMPBar ()
    {
        BarMP.GetComponent<UISlider> ().value
            = PCStats.currentMP / PCStats.maxMP;
    }
    
    void UpdateHungerBar ()
    {
        BarHunger.GetComponent<UISlider> ().value
            = 50;//TODO
    }

}
