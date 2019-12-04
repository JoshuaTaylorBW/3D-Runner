using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    private MovementManager movementManager; 
    private bool insideMovementTutorial; 
    private bool hasLearnedMovement; 

    private bool insideRollTutorial; 
    private bool hasLearnedRoll; 

    private bool insideCoverTutorial; 
    private bool hasLearnedCover; 
    
    void Start()
    {
        movementManager = GameObject.Find("Movement Manager").GetComponent<MovementManager>();
    }



    void Update()
    {
        
    }
}
