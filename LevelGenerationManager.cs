using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationManager : MonoBehaviour
{
    // Start is called before the first frame update

    private int score = 0;
    public List<GameObject> blocks; 
    private Random rnd; 
    private string[] eligibleBlockNames;
    public Vector3 positionToSpawn; 

    void Start() {
        eligibleBlockNames = levelOneBlockPaths;
        rnd = new Random(); 
        blocks = new List<GameObject>();
        blocks.Add(GameObject.Find("4_Blocks"));
        buildStartingBlocks();
    }

    void FixedUpdate() {
        for(int i = 0; i < blocks.Count; i++) {
           if(blocks[i].transform.position.z < -3360) {
                spanwNewBlock();
                destroyOldBlock(blocks[i]);
           } 
        }
    }

    void buildStartingBlocks() {
        GameObject blockToBuild;
        positionToSpawn = new Vector3(0, 0, 1680); //first is spawned at 800, each block is 1600 so 800 + 1600 = 2400   

        int levelToSpawnIndex = Random.Range(0, eligibleBlockNames.Length);

        for(int i = 0; i < 4; i++) {
            blockToBuild = Instantiate(Resources.Load("Blocks/" + eligibleBlockNames[levelToSpawnIndex]), positionToSpawn, Quaternion.identity) as GameObject;
            blocks.Add(blockToBuild);
            if(i < 3) positionToSpawn = new Vector3(0, 0, positionToSpawn.z + 1680);
        }
    }

    void spanwNewBlock() {
        GameObject blockToBuild;
        int levelToSpawnIndex = Random.Range(0, eligibleBlockNames.Length);
        positionToSpawn = new Vector3(0, 0, blocks[blocks.Count - 1].transform.position.z + 1680);

        blockToBuild = Instantiate(Resources.Load("Blocks/" + eligibleBlockNames[levelToSpawnIndex]), positionToSpawn, Quaternion.identity) as GameObject;
        blocks.Add(blockToBuild);
    }

    void destroyOldBlock(GameObject objectToDestroy) {
        blocks.Remove(objectToDestroy);
        Destroy(objectToDestroy);
    }

    private string[] levelOneBlockPaths = {"Level_1/4_Blocks", "Level_1/2_Rails"};
}

