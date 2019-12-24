using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int currentMultiplier = 1;
    public Text scoreText;
    public Text multiplierText;
    public Text perfectText;

    private PlayerCharacter player;
    private PlayerHealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>(); 
        healthManager = GameObject.Find("Player Character").GetComponent<PlayerHealthManager>(); 
        score = 0;        
    }

    // Update is called once per frame
    void Update()
    {

        if(!player.IsCovering() && !player.IsAiming() && !healthManager.IsDead()) {
            score += currentMultiplier;
        }

        if(player.IsCovering() && !healthManager.IsDead()) {
            score--;
        }

        scoreText.text = score.ToString(); 
        multiplierText.text = currentMultiplier.ToString() + "x"; 
    }

    public void ResetMultiplier() {
        currentMultiplier = 1;
    }

    public int GetScore() {
        return score;
    }

    public int GetMultiplier() {
        return currentMultiplier;
    }

    public void AddToMultiplier(int amountToAddBy) {
        currentMultiplier += amountToAddBy;
    }

    public void SetMultiplier(int newMultiplier) {
        currentMultiplier = newMultiplier;
    }

    public void DoubleMultiplier() {
        currentMultiplier += currentMultiplier;
    }
}
