using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHighScore;
    public int playerTotalCoins;

    private ScoreManager scoreManager;
    private MoneyManager moneyManager;

    void Start() {
        // SavePlayer(100, 100);
        PlayerData playerData = LoadPlayer();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        moneyManager = GameObject.Find("Money Manager").GetComponent<MoneyManager>();
        playerHighScore = playerData.highScore;
        playerTotalCoins = playerData.coinsCollected;

    }

    public void Restart() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoadTutorial() {
        Application.LoadLevel("Tutorial");
    }

    public void LoadGameScene() {
        Application.LoadLevel("Game");
    }

    public void SavePlayer(int newHighScore, int coins) {
        SaveSystem.SavePlayer(newHighScore, coins);
    }

    public PlayerData LoadPlayer() {
        return SaveSystem.LoadPlayer();
    }

    public void UpdateValues() {
        int newHighscore = scoreManager.GetScore() > GetPlayerHighScore() ? scoreManager.GetScore() : GetPlayerHighScore();
        int coins = GetPlayerTotalCoins() + moneyManager.GetTotalCoins(); 

        SavePlayer(newHighscore, coins);
    }

    public int GetPlayerHighScore() {
        return playerHighScore;
    }

    public int GetPlayerTotalCoins() {
        return playerTotalCoins;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
           Restart(); 
        } 
    }
}
