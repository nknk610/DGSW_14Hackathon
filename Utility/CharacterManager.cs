using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : ScriptableObject
{

    public static CharacterManager instance;

    public int Day = 1;
    public int hungry=50;
    public int mental=100;
    public int Temperature=100;
    public int houseQuality=100;
    public int tired=0;


    public static CharacterManager Get_instance()
    {
        if (instance == null)
        {
            instance = CreateInstance<CharacterManager>();
        }

        return instance;
    }
}
