using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour
{

    public PlayerCharacter playerCharacter;
    public GameManager gameManager;

    public Text totalCoinText;
    public bool hasUpdatedValues = false;


    void Start()
    {
       totalCoinText = GameObject.Find("Total Money Text").GetComponent<Text>();
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(playerCharacter == null) {
            playerCharacter = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        }else {
            if(playerCharacter.IsDead() && !hasUpdatedValues) {
                totalCoinText.text = gameManager.GetPlayerTotalCoins().ToString();
                hasUpdatedValues = true;
            }    
        } 
    }
}
