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
    public PlayerHealthManager healthManager;

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

        if(player.IsCovering()) {
            score--;
        }

        scoreText.text = score.ToString(); 
        multiplierText.text = currentMultiplier.ToString() + "x"; 
    }

    public void ResetMultiplier() {
        currentMultiplier = 1;
    }

    public void AddToMultiplier() {
        currentMultiplier++;
    }

}
