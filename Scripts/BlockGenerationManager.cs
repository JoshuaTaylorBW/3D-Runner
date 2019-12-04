using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerationManager : MonoBehaviour
{

    private bool secondLevelAdded;
    private LevelGenerationManager lgm; 
    public List<string>[] eligibleBlocks;
    private int rarityRoll;
    private int blockIndex;

    // Start is called before the first frame update
    void Start()
    {
        eligibleBlocks = new List<string>[] {
            commonLevelOneBlockPaths,
            uncommonLevelOneBlockPaths,
            rareLevelOneBlockPaths        
        };

        Debug.Log("Block Generation Manager Loaded");

    }

    void Update()
    {
    }

    public string GetBlockToSpawnPath() {
       SetNewBlockToSpawnIndex();
       Debug.Log(RarityAdjustedBlockArray()[blockIndex]);
       return RarityAdjustedBlockArray()[blockIndex]; 

    }

    void SetNewBlockToSpawnIndex() {
        rarityRoll = Random.Range(0, 20);
        blockIndex = Random.Range(0, RarityAdjustedBlockArray().Count);
    }

    List<string> RarityAdjustedBlockArray() {
        if(eligibleBlocks is null) {
            eligibleBlocks = new List<string>[] {
                commonLevelOneBlockPaths,
                uncommonLevelOneBlockPaths,
                rareLevelOneBlockPaths        
            };        
        }
        // return new List<string>{"Level_1/4_Blocks"};
        return rarityRoll < 10 ? eligibleBlocks[0] :
        rarityRoll >= 10 && rarityRoll < 17  ? eligibleBlocks[1] :
        eligibleBlocks[2];
    }

    void AddSecondLevelBlocks() {

    }


    //common, uncommon, rare (50, 35, 15) but done out of 200 so (10, 7, 3)
    public static List<string> commonLevelOneBlockPaths = new List<string>{"Level_1/4_Blocks", "Level_1/2_Rails", "Level_1/3_Rails_3_Trash_Cans", "Level_1/3_Trash_Cans", "Level_1/1_Cover_2_Trash_Cans_Middle_Right", "Level_1/1_Rail"};
    public static List<string> uncommonLevelOneBlockPaths = new List<string>{"Level_1/4_Blocks", "Level_1/2_Rails", "Level_1/3_Rails_3_Trash_Cans", "Level_1/3_Trash_Cans", "Level_1/1_Cover_2_Trash_Cans_Middle_Right", "Level_1/1_Rail"};
    public static List<string> rareLevelOneBlockPaths =  new List<string>{"Level_1/4_Blocks", "Level_1/2_Rails", "Level_1/3_Rails_3_Trash_Cans", "Level_1/3_Trash_Cans", "Level_1/1_Cover_2_Trash_Cans_Middle_Right", "Level_1/1_Rail"};

    //TO SPAWN A SINGLE BLOCK ALWAYS
    // public static List<string> commonLevelOneBlockPaths = new List<string>{"Level_1/1_Rail"};
    // public static List<string> uncommonLevelOneBlockPaths = new List<string>{"Level_1/1_Rail"};
    // public static List<string> rareLevelOneBlockPaths =  new List<string>{"Level_1/1_Rail"};

}
