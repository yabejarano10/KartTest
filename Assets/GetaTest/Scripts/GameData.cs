using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int racesPlayed;
    public int racesWon;
    public float fastest;

    public GameData(int played, int won, float fast)
    {
        racesPlayed = played;
        racesWon = won;
        fastest = fast;
    }
}
