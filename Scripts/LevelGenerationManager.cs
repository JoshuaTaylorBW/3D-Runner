using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationManager : MonoBehaviour
{
    //THIS FILE JUST PLACES THE OBJECTS. TO CHANGE GENERATION BEHAVIOR GO TO BlockGenerationManager
    private int score = 0;
    public List<GameObject> blocks; 
    private BlockGenerationManager blockGenerationManager;
    private Vector3 positionToSpawn; 

    public int blocksBuilt; 

    void Start() {
        blockGenerationManager = GetComponent<BlockGenerationManager>();
        blocks = new List<GameObject>();
        blocks.Add(GameObject.Find("Starting Block"));
        buildStartingBlocks();
    }

    void buildStartingBlocks() {
        GameObject blockToBuild;
        string levelToSpawnPath = blockGenerationManager.GetBlockToSpawnPath();
        positionToSpawn = new Vector3(0, 0, 1680); //first is spawned at 800, each block is 1600 so 800 + 1600 = 2400   

        for(int i = 0; i < 4; i++) {
            blockToBuild = Instantiate(Resources.Load("Blocks/" + levelToSpawnPath), positionToSpawn, Quaternion.identity) as GameObject;
            blocks.Add(blockToBuild);
            if(i < 3) positionToSpawn = new Vector3(0, 0, positionToSpawn.z + 1680);
        }

        blocksBuilt = 4;

    }

    void FixedUpdate() {
        for(int i = 0; i < blocks.Count; i++) {
           if(blocks[i].transform.position.z < -3360) {
                spanwNewBlock();
                destroyOldBlock(blocks[i]);
           } 
        }
    }

    void spanwNewBlock() {
        GameObject blockToBuild;
        string levelToSpawnPath = blockGenerationManager.GetBlockToSpawnPath();
        positionToSpawn = new Vector3(0, 0, blocks[blocks.Count - 1].transform.position.z + 1680);

        blockToBuild = Instantiate(Resources.Load("Blocks/" + levelToSpawnPath), positionToSpawn, Quaternion.identity) as GameObject;
        blocks.Add(blockToBuild);
        blocksBuilt++;
    }

    void destroyOldBlock(GameObject objectToDestroy) {
        blocks.Remove(objectToDestroy);
        Destroy(objectToDestroy);
    }

    public List<GameObject> GetBlocks() {
        return blocks;
    }

    public int GetScore() {
        return score;
    }

    public int GetAmountOfBlocksBuilt() {
        return blocksBuilt;
    } 

}

