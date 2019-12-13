using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSingleEnemy : MonoBehaviour
{
    public EnemyGenerationManager egm;
    public GameObject tutorialTextToShow; 

    // Start is called before the first frame update
    void Start()
    {
        egm = GameObject.Find("Enemy Generation Manager").GetComponent<EnemyGenerationManager>();
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Check For Cover") {
            egm.GenerateSingleTutorialEnemy(); 
            tutorialTextToShow.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
