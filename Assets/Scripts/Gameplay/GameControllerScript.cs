using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{
    public int score = 100;

    private Character PCPacket;

    void Awake ()
    {
    }

    void Start ()
    {
        // TODO: insure against empty/non-existent packet object
        PCPacket = GameObject.Find ("PC Packet").GetComponent<Character> ();
	
        PlayerStats PCStat = GameObject.FindGameObjectWithTag (Tags.player)
            .GetComponent<PlayerStats> ();

        PCStat.Init (PCPacket);


    }
	
    void Update ()
    {
	
    }
}
