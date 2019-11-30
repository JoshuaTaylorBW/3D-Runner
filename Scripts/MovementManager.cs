using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    public bool moving = true;

    public float currentMovementSpeed;

    public float firstMovementSpeed;
    public int blocksBeforeSecondSpeed;
    public float secondMovementSpeed;
    private LevelUpManager lum;
    private LevelGenerationManager lgm;

    public int blockSpeedLevel = 1;

    void Start() {
        lum = GameObject.Find("Level Up Manager").GetComponent<LevelUpManager>();
        lgm = GameObject.Find("Level Generation Manager").GetComponent<LevelGenerationManager>();
        currentMovementSpeed = firstMovementSpeed; 
    }

    public float GetMovementSpeed() {
        return currentMovementSpeed;
    }

    public bool IsMoving() {
        return moving;
    }

    public void PlayMovement() {
        moving = true;
    }

    public void PauseMovement() {
        moving = false;
    }

    void Update() {
        if(lum.GetCurrentSpeed() == 2) {
            currentMovementSpeed = secondMovementSpeed;
            if(blockSpeedLevel != 2) {
                SpeedUpBlocks();
            }
        }
    }

    void SpeedUpBlocks() {
        List<GameObject> blocks = lgm.GetBlocks();
        foreach(GameObject block in blocks) {
           MoveTowardCamera blockBehave = block.GetComponent<MoveTowardCamera>();
           blockBehave.SetMovementSpeed(currentMovementSpeed);
        }
        
        blockSpeedLevel++;
    }
}
