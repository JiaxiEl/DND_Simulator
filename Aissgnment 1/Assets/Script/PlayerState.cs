using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public string Character_Name, Classes,Races,Alignment;
    public int Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma;
    public int speedWalking, Hit_Points, Experience_Points, Armor_Class, MAX_Experience_Point;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
        
    }
}
