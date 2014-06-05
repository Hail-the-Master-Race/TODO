using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
    private GameObject PC;
    private PlayerStats PCStats;

    private GameControllerScript GameController;

    private UILabel LabelPCName;
    private UILabel LabelPCLevelClass;
    private UILabel LabelScoreValue;
    private GameObject BarHP, BarMP, BarHunger, BarEXP;

	public bool isPaused = false;
	public void UpdateIsPasued () {
		isPaused = !isPaused;
	}
	
    public void LateStart ()
    {
		PC = GameObject.FindGameObjectWithTag (Tags.player);
		PCStats = PC.GetComponent<PlayerStats> ();
	
		GameController = GameObject.FindGameObjectWithTag (Tags.gameController)
            .GetComponent<GameControllerScript> ();

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
	
    public void OurUpdate ()
    {
		if ((PC = GameObject.FindGameObjectWithTag (Tags.player)) == null)
			return;
		if (PCStats == null)
			PCStats = PC.GetComponent<PlayerStats> ();

        UpdateBars ();
        UpdatePCInfo ();
        UpdateScore ();
		if (Input.GetKeyDown(KeyCode.Escape))
			UpdateIsPasued();
    }

    void UpdatePCInfo ()
    {
        LabelPCName.text = PCStats.name;
        LabelPCLevelClass.text = ("Lvl." + PCStats.Lvl + " " + PCStats.characterClass);
    }

    void UpdateScore ()
    {
        LabelScoreValue.text = GameController.score.ToString ();
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
