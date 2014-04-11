using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
    private GameObject PC;
    private PlayerStats PCStats;

    private UILabel LabelPCInfo;
    private GameObject BarHP, BarMP, BarHunger, BarEXP;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.FindGameObjectWithTag ("Player");
        PCStats = PC.GetComponent<PlayerStats> ();
        LabelPCInfo = GameObject.FindGameObjectWithTag ("UI: PC Info")
            .GetComponent<UILabel> ();

        BarHP = GameObject.FindGameObjectWithTag ("UI: HP Bar");
        BarMP = GameObject.FindGameObjectWithTag ("UI: MP Bar");
        BarHunger = GameObject.FindGameObjectWithTag ("UI: Hunger Bar");
        BarEXP = GameObject.FindGameObjectWithTag ("UI: EXP Bar");
    }
	
    // Update is called once per frame
    void Update ()
    {
        UpdateBars ();

        LabelPCInfo.text = PCStats.name;
        LabelPCInfo.text += (" Lvl." + PCStats.Lvl);
    }

    void UpdateBars ()
    {
        UpdateHPBar ();
        UpdateMPBar ();
        UpdateHungerBar ();
        UpdateEXPBar ();
    }
    
    void UpdateHPBar ()
    {
        BarHP.GetComponent<UISlider> ().value 
            = (float)PCStats.currentHP / (float)PCStats.MaxHP;       
    }
    
    void UpdateMPBar ()
    {
        BarMP.GetComponent<UISlider> ().value
            = (float)PCStats.currentMP / (float)PCStats.MaxMP;
    }
    
    void UpdateHungerBar ()
    {
        BarHunger.GetComponent<UISlider> ().value
            = (float)PCStats.currentHunger / (float)PCStats.MaxHunger;
    }
    
    void UpdateEXPBar ()
    {
        BarEXP.GetComponent<UISlider> ().value
            = (float)PCStats.currentEXP / (float)PCStats.MaxEXP;
    }
}
