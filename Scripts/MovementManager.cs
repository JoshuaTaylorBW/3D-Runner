using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{

    public bool isTutorial = false;
    public bool moving = true;
    public int blockSpeedLevel = 1;

    private PlayerCharacter player; 

    public float currentMovementSpeed;

    [Header("Stage One")]
    public float firstMovementSpeed;

    [Header("Stage Two")]
    public int blocksBeforeSecondSpeed;
    public float secondMovementSpeed;

    [Header("Stage Three")]
    public int blocksBeforeThirdSpeed;
    public float thirdMovementSpeed;

    [Header("Stage Four")]
    public int blocksBeforeFourthSpeed;
    public float fourthMovementSpeed;

    [Header("Stage Five")]
    public int blocksBeforeFifthSpeed;
    public float fifthMovementSpeed;

    public bool hasAddedCharacterMovement = false;

    private LevelUpManager lum;
    private LevelGenerationManager lgm;

    private bool hasNotMovedToTwo = true;
    private bool hasNotMovedToThree = true;
    private bool hasNotMovedToFour = true;


    void Start() {
        if(!isTutorial) {
            lum = GameObject.Find("Level Up Manager").GetComponent<LevelUpManager>();
            lgm = GameObject.Find("Level Generation Manager").GetComponent<LevelGenerationManager>();    
        }
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
        if(!isTutorial) {
            
            if(lum.GetCurrentSpeedLevel() == 1) {
                if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeSecondSpeed && hasNotMovedToTwo) {
                    lgm.SpawnSpeedUpBlock();
                    hasNotMovedToTwo = false;
                }    
            } 

            if(lum.GetCurrentSpeedLevel() == 2) {
                currentMovementSpeed = secondMovementSpeed;
                if(blockSpeedLevel != 2) {
                    SpeedUpBlocks();
                }

                if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeThirdSpeed && hasNotMovedToThree) {
                    lgm.SpawnSpeedUpBlock();
                    hasNotMovedToThree = false;
                }
            }

            if(lum.GetCurrentSpeedLevel() == 3) {
                currentMovementSpeed = thirdMovementSpeed;
                if(blockSpeedLevel != 3) {
                    SpeedUpBlocks();
                } 

                if(lgm.GetAmountOfBlocksBuilt() > blocksBeforeFourthSpeed && hasNotMovedToFour) {
                    lgm.SpawnSpeedUpBlock();
                    hasNotMovedToFour = false; 
                }
            }
            if(lum.GetCurrentSpeedLevel() == 4) {
                currentMovementSpeed = fourthMovementSpeed;
                if(blockSpeedLevel != 4) {
                    SpeedUpBlocks();
                }
            }
            if(lum.GetCurrentSpeedLevel() == 5) {
                currentMovementSpeed = fifthMovementSpeed;
                if(blockSpeedLevel != 5) {
                    SpeedUpBlocks();
                }
            }
        }

        if(player == null) {
            player = GameObject.Find("Player Character").GetComponent<PlayerCharacter>();
            currentMovementSpeed += player.GetBaseMovementSpeed();
            firstMovementSpeed += player.GetBaseMovementSpeed();
            secondMovementSpeed += player.GetBaseMovementSpeed();
            thirdMovementSpeed += player.GetBaseMovementSpeed();
            fourthMovementSpeed += player.GetBaseMovementSpeed();
            fifthMovementSpeed += player.GetBaseMovementSpeed(); 

            List<GameObject> blocks = lgm.GetBlocks();
            foreach(GameObject block in blocks) {
                MoveTowardCamera blockBehave = block.GetComponent<MoveTowardCamera>();
                blockBehave.SetMovementSpeed(currentMovementSpeed);
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
