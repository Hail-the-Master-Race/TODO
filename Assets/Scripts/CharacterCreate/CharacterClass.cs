using UnityEngine;
using System.Collections;

public class CharacterClass
{
    private string Name;
    private string Description;

    private int AffinSTR;
    private int AffinDEX;
    private int AffinFRT;

    public CharacterClass (string name, string description,
                           int aS, int aD, int aF)
    {
        Name = name;
        Description = description;
        AffinSTR = aS;
        AffinDEX = aD;
        AffinFRT = aF;
    }
}
