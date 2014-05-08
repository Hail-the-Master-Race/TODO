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
    
    public string getName ()
    {
        return Name;
    }

    public string getDescription ()
    {
        return Description;
    }

    public int getAffinSTR ()
    {
        return AffinSTR;
    }

    public int getAffinDEX ()
    {
        return AffinDEX;
    }

    public int getAffinFRT ()
    {
        return AffinFRT;
    }
}

public class CharacterClasses
{
    public static CharacterClass Warrior 
        = new CharacterClass ("Warrior", Strings.ClassDescripWarrior,
                              4, 2, 3);
    public static CharacterClass Rogue 
        = new CharacterClass ("Rogue", Strings.ClassDescripRogue,
                              3, 4, 2);
    public static CharacterClass Defender 
        = new CharacterClass ("Defender", Strings.ClassDescripDefender,
                              3, 2, 4);
    public static CharacterClass Peasant 
        = new CharacterClass ("Peasant", Strings.ClassDescripPeasant,
                              3, 3, 3);
}
