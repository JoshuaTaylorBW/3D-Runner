using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public int currentStage;
    public int currentSpeed = 1;
    public int blocksBeforeSecondSpeed;
    private LevelGenerationManager lgm;

    void Start()
    {
        lgm = GameObject.Find("Level Generation Manager").GetComponent<LevelGenerationManager>();
    }

    void Update()
    {
        if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeSecondSpeed) {
            currentSpeed = 2;
        } 
    }

    public int GetCurrentStage() {
        return currentStage;
    }

    public int GetCurrentSpeed() {
        return currentSpeed;
    }

}
