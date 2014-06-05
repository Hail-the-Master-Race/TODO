using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{
    public int score = 100;

    private Character PCPacket;
	private UIScript OurUIScript;
	private Player OurPlayerSpawner;
	private EnemyGenerate enemyGenerator;
	private ItemSpawn itemSpawner;

    void Awake ()
    {
		OurUIScript      = GetComponent<UIScript> ();
		OurPlayerSpawner = GameObject.Find("PlayerSpawn").GetComponent<Player> ();
		enemyGenerator   = GameObject.Find("Enemy Generator").GetComponent<EnemyGenerate> ();
		itemSpawner = GameObject.Find ("Item Spawner").GetComponent<ItemSpawn> ();
    }

    void Start ()
    {
        // TODO: insure against empty/non-existent packet object
        //PCPacket = GameObject.Find ("PC Packet").GetComponent<Character> ();
	
        //PlayerStats PCStat = GameObject.FindGameObjectWithTag (Tags.player)
         //   .GetComponent<PlayerStats> ();

        //PCStat.Init (PCPacket);

		OurPlayerSpawner.Spawn ();

		OurUIScript.LateStart ();

		enemyGenerator.LateStart ();
		itemSpawner.LateStart ();
    }
	
    void Update ()
    {
		OurUIScript.OurUpdate ();
    }
}
