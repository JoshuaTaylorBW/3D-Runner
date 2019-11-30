using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerationManager : MonoBehaviour
{

    public float minTimeBetweenGenerations;
    public float maxTimeBetweenGenerations;
    private GameObject EnemyToBirth;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine("GenerateNewEnemy"); 
    }

    IEnumerator GenerateNewEnemy() {
        float timeUntilNextGeneration = Random.Range(minTimeBetweenGenerations, maxTimeBetweenGenerations); 
        bool moveRight = Random.Range(0,1) == 0 ? true : false;
        Vector3 positionToSpawn = new Vector3(moveRight ? -300f : 300f, -36.9f, 1108f);
        yield return new WaitForSeconds(timeUntilNextGeneration);
        EnemyToBirth = Instantiate(Resources.Load("Enemies/Enemy"), positionToSpawn, Quaternion.identity) as GameObject; 
        EnemyToBirth.GetComponent<Enemy>().SetMoveRight(moveRight);
        StartCoroutine("GenerateNewEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
