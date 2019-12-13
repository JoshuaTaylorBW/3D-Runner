using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coinsCollected; 
    public int highScore;

    public PlayerData(int coins, int score) {
        coinsCollected = coins;
        highScore = score;
    }
}
