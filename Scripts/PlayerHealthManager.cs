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
    public GameObject restartButton;
    public GameObject gameOverText;
    public GameObject tutorialButton;

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
                gameOverText.SetActive(true);
                tutorialButton.SetActive(true);
                restartButton.SetActive(true);
                health--;
            } 
        } 
    }

    public bool IsDead() {
       return health == 0; 
    }
}

