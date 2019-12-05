using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameObject speedUpText;
    
    public int currentStage;
    public int currentSpeedLevel = 1;
    public int blocksBeforeSecondStage;
    public int blocksBeforeThirdStage;
    public int blocksBeforeFourthStage;
    public int blocksBeforeFifthStage;

    private bool hasNotMovedToTwo = true;
    private bool hasNotMovedToThree = true;
    private bool hasNotMovedToFour = true;
    private bool hasNotMovedToFive = true;
    private LevelGenerationManager lgm;


    void Start()
    {
        lgm = GameObject.Find("Level Generation Manager").GetComponent<LevelGenerationManager>();
    }

    public int GetCurrentStage() {
        return currentStage;
    }

    public int GetCurrentSpeedLevel() {
        return currentSpeedLevel;
    }

    void Update() {
        if(currentStage == 1) {
            if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeSecondStage && hasNotMovedToTwo) {
                currentStage = 2;
                hasNotMovedToTwo = false;
            }    
        }else if(currentStage == 2) {
            if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeThirdStage && hasNotMovedToThree) {
                currentStage = 3;
                hasNotMovedToThree = false;
            }
        }else if(currentStage == 3) {
            if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeFourthStage && hasNotMovedToFour) {
                currentStage = 4;
                hasNotMovedToFour = false;
            }
        }else if(currentStage == 4) {
            if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeFifthStage && hasNotMovedToFive) {
                currentStage = 5;
                hasNotMovedToFive = false;
            }
        }
    }

    public void LevelUp() {
        currentSpeedLevel++;
        speedUpText.SetActive(true); 
    }
}
