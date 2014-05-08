using UnityEngine;
using System.Collections;

public class CharacterClass
{
    private string _name;
    public string Name { get { return _name; } }
    private string _description;
    public string Description { get { return _description; } }
    
    private int _affinSTR;
    public int AffinSTR { get { return _affinSTR; } }
    private int _affinDEX;
    public int AffinDEX { get { return _affinDEX; } }
    private int _affinFRT;
    public int AffinFRT { get { return _affinFRT; } }
    
    public CharacterClass (string name, string description,
                           int aS, int aD, int aF)
    {
        _name = name;
        _description = description;
        _affinSTR = aS;
        _affinDEX = aD;
        _affinFRT = aF;
    }
}