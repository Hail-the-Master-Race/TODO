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
	private NetworkManagerScript networkManager;

    void Awake ()
    {
		OurUIScript      = GetComponent<UIScript> ();
		OurPlayerSpawner = GameObject.Find("PlayerSpawn").GetComponent<Player> ();
		enemyGenerator   = GameObject.Find("Enemy Generator").GetComponent<EnemyGenerate> ();
		itemSpawner      = GameObject.Find("Item Spawner").GetComponent<ItemSpawn> ();
		networkManager   = GameObject.Find("NetworkManager").GetComponent<NetworkManagerScript> ();
    }

    void Start ()
    {
		if (networkManager.isOnline && Network.isClient)
			return;

		networkManager.playerTag = "Player1";
		OurPlayerSpawner.Spawn (1);

		OurUIScript.LateStart ();

		enemyGenerator.LateStart ();
		itemSpawner.LateStart ();
    }
	
    void Update ()
    {
		OurUIScript.OurUpdate ();
    }
}
