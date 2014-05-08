using UnityEngine;
using System.Collections;


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