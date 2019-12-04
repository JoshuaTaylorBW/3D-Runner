using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public GameObject speedUpText;
    
    public int currentStage;
    public int currentSpeed = 1;
    public bool hasNotChanged = true;
    public int blocksBeforeSecondSpeed;
    private LevelGenerationManager lgm;

    void Start()
    {
        lgm = GameObject.Find("Level Generation Manager").GetComponent<LevelGenerationManager>();
    }

    public int GetCurrentStage() {
        return currentStage;
    }

    public int GetCurrentSpeed() {
        return currentSpeed;
    }

    void Update() {
        if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeSecondSpeed && hasNotChanged) {
            lgm.SpawnSpeedUpBlock();
            hasNotChanged = false;
        }
    }

    public void LevelUp() {
        currentSpeed++;
        speedUpText.SetActive(true); 
    }
}
