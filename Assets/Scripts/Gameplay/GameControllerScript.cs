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
        PCPacket = GameObject.Find ("PC Packet").GetComponent<Character> ();
	
        PlayerStats PCStat = GameObject.Find ("Player")
            .GetComponent<PlayerStats> ();

        PCStat.Init (PCPacket);
    }
	
    void Update ()
    {
	
    }
}
