using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHighScore;
    public int playerTotalCoins;

    private ScoreManager scoreManager;
    private MoneyManager moneyManager;

    private TouchControls touchControls;

    void Start() {
        PlayerData playerData = LoadPlayer();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();
        moneyManager = GameObject.Find("Money Manager").GetComponent<MoneyManager>();
        touchControls = GameObject.Find("Touch Controls").GetComponent<TouchControls>();
        playerHighScore = playerData.highScore;
        playerTotalCoins = playerData.coinsCollected;
    }

    public void Restart() {
        touchControls.StopWatchingForTouch();
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
        playerHighScore = scoreManager.GetScore() > playerHighScore ? scoreManager.GetScore() : playerHighScore;
        playerTotalCoins += moneyManager.GetTotalCoins(); 
        SavePlayer(playerHighScore, playerTotalCoins);
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
