using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
    private GameObject PC;
    private PlayerStats PCStats;

    private GameStats GameStats;

    private UILabel LabelPCName;
    private UILabel LabelPCLevelClass;
    private UILabel LabelScoreValue;
    private GameObject BarHP, BarMP, BarHunger, BarEXP;

    // Use this for initialization
    void Start ()
    {
        PC = GameObject.Find ("Player");
        PCStats = PC.GetComponent<PlayerStats> ();

        GameStats = GameObject.Find ("Game Controller")
            .GetComponent<GameStats> ();

        LabelPCName = GameObject.Find ("PC Info: Name")
            .GetComponent<UILabel> ();
        LabelPCLevelClass = GameObject.Find ("PC Info: Level and Class")
            .GetComponent<UILabel> ();
        LabelScoreValue = GameObject.Find ("Score: Info")
            .GetComponent<UILabel> ();

        BarHP = GameObject.Find ("1. Bar (HP)");
        BarMP = GameObject.Find ("2. Bar (MP)");
        BarHunger = GameObject.Find ("3. Bar (Hunger)");
        BarEXP = GameObject.Find ("4. Bar (EXP)");
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
        LabelPCName.text = PCStats.name;
        LabelPCLevelClass.text = ("Lvl." + PCStats.Lvl + " " + PCStats.characterClass);
    }

    void UpdateScore ()
    {
        LabelScoreValue.text = GameStats.score.ToString ();
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
