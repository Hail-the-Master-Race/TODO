using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
    private GameObject PC;
    private PlayerStats PCStats;

    private GameStats GameStats;

    private UILabel LabelPCInfo;
    private UILabel LabelScore;
    private GameObject BarHP, BarMP, BarHunger, BarEXP;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.Find ("Player");
        PCStats = PC.GetComponent<PlayerStats> ();

        GameStats = GameObject.Find ("Game Controller")
            .GetComponent<GameStats> ();

        LabelPCInfo = GameObject.Find ("PC Info")
            .GetComponent<UILabel> ();
        LabelScore = GameObject.Find ("Score")
            .GetComponent<UILabel> ();

        BarHP = GameObject.Find ("Bar (HP)");
        BarMP = GameObject.Find ("Bar (MP)");
        BarHunger = GameObject.Find ("Bar (Hunger)");
        BarEXP = GameObject.Find ("Bar (EXP)");
    }
	
    // Update is called once per frame
    void Update ()
    {
        UpdateBars ();
        UpdatePCInfo ();
        UpdateScore ();
    }

    void UpdatePCInfo ()
    {
        LabelPCInfo.text = PCStats.name;
        LabelPCInfo.text += ("\n Lvl." + PCStats.Lvl + " " + PCStats.characterClass);
    }

    void UpdateScore ()
    {
        LabelScore.text = "Score: " + GameStats.score.ToString ();
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
