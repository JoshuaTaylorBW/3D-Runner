using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMovement : MonoBehaviour
{
    private MovementManager movementManager; 
    public GameObject tutorialTextToShow; 

    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Check For Cover") {
            movementManager.PauseMovement();
            tutorialTextToShow.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
