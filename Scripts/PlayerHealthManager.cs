using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    public bool godMode = false;

    public int health = 2;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject fullHealthHeart;
    public GameObject halfHealthHeart;
    public GameObject gameOverScreen;
    public PlayerCharacter player;


    void Start() {
        fullHealthHeart = GameObject.Find("Full health heart");
        halfHealthHeart = GameObject.Find("Half health heart");
        gameOverScreen = GameObject.Find("Game Over Screen"); 
        gameOverScreen.SetActive(false); 

        if(health == 1) {
            fullHealthHeart.SetActive(false);
            halfHealthHeart.GetComponent<RectTransform>().anchoredPosition = new Vector2(-32f, -33);
        }
    }

    public void getHit() {
        if(!godMode) {
            if(health == 2) 
            {
                fullHealthHeart.GetComponent<Image>().sprite = emptyHeart;
                health--;
            }
            else if(health == 1)
            {
                halfHealthHeart.GetComponent<Image>().sprite = emptyHeart;
                gameOverScreen.SetActive(true);
                GetComponent<PlayerCharacter>().Die();
                health--;
            } 
        } 
    }

    public bool IsDead() {
       return health == 0; 
    }
}

