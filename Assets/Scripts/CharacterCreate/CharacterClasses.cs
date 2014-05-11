using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterClasses : MonoBehaviour
{
    private static CharacterClass Warrior 
        = new CharacterClass ("Warrior", Strings.ClassDescripWarrior,
                              4, 2, 3);
    private static CharacterClass Rogue 
        = new CharacterClass ("Rogue", Strings.ClassDescripRogue,
                              3, 4, 2);
    private static CharacterClass Defender 
        = new CharacterClass ("Defender", Strings.ClassDescripDefender,
                              3, 2, 4);
    private static CharacterClass Peasant 
        = new CharacterClass ("Peasant", Strings.ClassDescripPeasant,
                              3, 3, 3);

    private static Dictionary<string, CharacterClass> ClassDictionary
        = new Dictionary<string, CharacterClass> 
    {
        { Warrior.Name, Warrior },
        { Rogue.Name, Rogue },
        { Defender.Name, Defender },
        { Peasant.Name, Peasant }
    };

    public static CharacterClass getClass (string name)
    {
        return ClassDictionary [name];
    }
}