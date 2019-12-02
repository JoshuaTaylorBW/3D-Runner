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
        int rightInt = Random.Range(0,2);
        bool moveRight = rightInt == 0 ? true : false;
        Vector3 positionToSpawn = new Vector3(moveRight ? -300f : 300f, -36.9f, 1108f);

        yield return new WaitForSeconds(timeUntilNextGeneration);

        EnemyToBirth = Instantiate(Resources.Load("Enemies/Enemy"), positionToSpawn, Quaternion.identity) as GameObject; 
        EnemyToBirth.GetComponent<Enemy>().SetMoveRight(moveRight);
        EnemyToBirth.GetComponent<SpriteRenderer>().flipX = (!moveRight);
        StartCoroutine("GenerateNewEnemy");
    }

    void Update()
    {
        
    }
}
